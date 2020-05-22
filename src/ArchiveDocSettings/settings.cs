using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nwuram.Framework.Settings.Connection;

namespace ArchiveDocSettings
{
    public partial class settings : UserControl
    {
        private DataTable dtExtension, dtDepartmentsAccessView, dtDepartmentsAccessView_view;
        public settings()
        {
            InitializeComponent();
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            dgvExtension.AutoGenerateColumns = false;
            dgvData.AutoGenerateColumns = false;
        }

        private void settings_Load(object sender, EventArgs e)
        {
            init_depsCombobox();
            getDepartmentsAccessView();

            init_groupFile();
            getExtension();
        }

        #region "Departments"
        private void init_depsCombobox()
        {
            DataTable dtDeps = null;
            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0)
            { dtDeps = task.Result.Copy(); task = null; }

            cmbDeps.DataSource = dtDeps;
            cmbDeps.DisplayMember = "name";
            cmbDeps.ValueMember = "id";

            task = Config.hCntMain.getDeps();
            task.Wait();
            dtDepartmentsAccessView = task.Result;
            if (dtDepartmentsAccessView != null && !dtDepartmentsAccessView.Columns.Contains("isSelect"))
            {               
                    DataColumn col = new DataColumn("isSelect", typeof(bool));
                    col.DefaultValue = false;
                    dtDepartmentsAccessView.Columns.Add(col);
                    dtDepartmentsAccessView.AcceptChanges();
            }

            if (dtDepartmentsAccessView != null && !dtDepartmentsAccessView.Columns.Contains("id_DepartmentsAccessView"))
            {
                DataColumn col = new DataColumn("id_DepartmentsAccessView", typeof(int));
                col.DefaultValue = 0;
                dtDepartmentsAccessView.Columns.Add(col);
                dtDepartmentsAccessView.AcceptChanges();
            }


            dgvData.DataSource = dtDepartmentsAccessView;
        }

        private void getDepartmentsAccessView()
        {            
            int id_deps = int.Parse(cmbDeps.SelectedValue.ToString());
            dtDepartmentsAccessView_view = dtDepartmentsAccessView.Copy();

            Task<DataTable> task = Config.hCntMain.getDepartmentsAccessView(id_deps);
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0)
            {                
                foreach (DataRow row in task.Result.Rows)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtDepartmentsAccessView_view.AsEnumerable().Where(r => r.Field<Int16>("id") == (int)row["id_DepartmentsView"]);
                    if (rowCollect.Count() > 0)
                    {
                        rowCollect.First()["id_DepartmentsAccessView"] = row["id"];
                        rowCollect.First()["isSelect"] = row["isActive"];
                    }
                }
                dtDepartmentsAccessView_view.AcceptChanges();
                dgvData.DataSource = dtDepartmentsAccessView_view;
            }
            else
                dgvData.DataSource = dtDepartmentsAccessView_view;
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getDepartmentsAccessView();
            setFilterDepartmentsAccessView();
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cUse.Index)
            {
                if (dtDepartmentsAccessView_view.DefaultView[e.RowIndex]["isSelect"] is bool && dtDepartmentsAccessView_view.DefaultView[e.RowIndex]["id_DepartmentsAccessView"] is int)
                {
                    int id = (int)dtDepartmentsAccessView_view.DefaultView[e.RowIndex]["id_DepartmentsAccessView"];
                    bool isActive = (bool)dtDepartmentsAccessView_view.DefaultView[e.RowIndex]["isSelect"];

                    int id_Departments = int.Parse(cmbDeps.SelectedValue.ToString());
                    int id_DepartmentsView = (Int16)dtDepartmentsAccessView_view.DefaultView[e.RowIndex]["id"];                    

                    Task<DataTable> task = Config.hCntMain.setDepartmentsAccessView(id, id_Departments, id_DepartmentsView, isActive, false, 0);
                    task.Wait();

                    if (task.Result == null)
                    {
                        MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int result = (int)task.Result.Rows[0]["id"];

                    if (result == -1)
                    {
                        MessageBox.Show(Config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dtDepartmentsAccessView_view.DefaultView[e.RowIndex]["id_DepartmentsAccessView"] = result;
                }
            }
        }

        private void tbNameDeps_TextChanged(object sender, EventArgs e)
        {
            setFilterDepartmentsAccessView();
        }

        private void setFilterDepartmentsAccessView()
        {
            if (dtDepartmentsAccessView_view == null || dtDepartmentsAccessView_view.Rows.Count == 0)
            {
                return;
            }

            try
            {
                string filter = "";

                if (tbNameDeps.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + string.Format("name like '%{0}%'", tbNameDeps.Text.Trim());

                //filter += (filter.Length == 0 ? "" : " and ") + string.Format("isActive = 1", "");

                dtDepartmentsAccessView_view.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtDepartmentsAccessView_view.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
            }
        }

        #endregion

        #region  "Extension"

        private void init_groupFile()
        {
            Task<DataTable> task = Config.hCntMain.getGroupFile(true);
            task.Wait();

            cmbTypeDoc.DataSource = task.Result;
            cmbTypeDoc.DisplayMember = "cName";
            cmbTypeDoc.ValueMember = "id";
        }

        private void getExtension()
        {
            Task.Run(() =>
            {
                Config.DoOnUIThread(() => { this.Enabled = false; }, this.ParentForm);

                Task<DataTable> task = Config.hCntMain.getTypeFile();
                task.Wait();
                dtExtension = task.Result;

                DataGridViewColumn oldCol = dgvExtension.SortedColumn;
                ListSortDirection direction = ListSortDirection.Ascending;
                if (oldCol != null)
                {
                    if (dgvExtension.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        direction = ListSortDirection.Descending;
                    }
                }
                Config.DoOnUIThread(() =>
                {
                    setFilter();
                    dgvExtension.DataSource = dtExtension;
                }, this.ParentForm);


                if (oldCol != null)
                {
                    dgvExtension.Sort(oldCol, direction);
                    oldCol.HeaderCell.SortGlyphDirection =
                         direction == ListSortDirection.Ascending ?
                         System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
                }



                Config.DoOnUIThread(() => { this.Enabled = true; }, this.ParentForm);
            });
        }

        private void setFilter()
        {
            if (dtExtension == null || dtExtension.Rows.Count == 0)
            {                
                return;
            }

            try
            {
                string filter = "";

                if ((int)cmbTypeDoc.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_GroupFile = {cmbTypeDoc.SelectedValue}";

                filter += (filter.Length == 0 ? "" : " and ") + string.Format("isActive = 1", "");

                dtExtension.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtExtension.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
            }
        }
       
        private void cmbTypeDoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }
      
        private void dgvExtension_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cUse.Index)
            {
                if (dtExtension.DefaultView[e.RowIndex]["isUse"] is bool && dtExtension.DefaultView[e.RowIndex]["id"] is int)
                {
                    int id = (int)dtExtension.DefaultView[e.RowIndex]["id"];
                    bool isActive = (bool)dtExtension.DefaultView[e.RowIndex]["isActive"];

                    string Extension = (string)dtExtension.DefaultView[e.RowIndex]["Extension"];
                    int id_GroupFile = (int)dtExtension.DefaultView[e.RowIndex]["id_GroupFile"];
                    bool isUse = (bool)dtExtension.DefaultView[e.RowIndex]["isUse"];

                    Task<DataTable> task = Config.hCntMain.setTypeFile(id, id_GroupFile, Extension, isUse, isActive, false, 0);
                    task.Wait();

                    if (task.Result == null)
                    {
                        MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int result = (int)task.Result.Rows[0]["id"];

                    if (result == -1)
                    {
                        MessageBox.Show(Config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        return;
                    }
                }
            }
        }

        #endregion
    }
}

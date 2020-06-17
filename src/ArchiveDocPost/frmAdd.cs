using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveDocPost
{
    public partial class frmAdd : Form
    {
        public DataRowView row { set; private get; }

        private bool isEditData = false;
        private string oldName;
        private int id = 0;
        private DataTable dtDeps;

        public frmAdd()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
            dgvData.AutoGenerateColumns = false;
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {           
            if (row != null)
            {
                id = (int)row["id"];
                tbName.Text = (string)row["cName"];
                oldName = tbName.Text.Trim();
            }

            init_deps();

            isEditData = false;
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void init_deps()
        {
            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();

            if (task.Result != null && task.Result.Rows.Count > 0)
            {
                dtDeps = task.Result.Copy();
                task = null;
                DataColumn col = new DataColumn("isSelect", typeof(bool));
                col.DefaultValue = false;
                dtDeps.Columns.Add(col);

                col = new DataColumn("idLinkPost", typeof(int));
                col.DefaultValue = 0;
                dtDeps.Columns.Add(col);
                dtDeps.AcceptChanges();
                
                task = Config.hCntMain.getPostLinkDep(id);
                task.Wait();
                if (task.Result != null && task.Result.Rows.Count > 0)
                {
                    foreach (DataRow row in task.Result.Rows)
                    {
                        EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == (int)row["id_Departments"]);
                        if (rowCollect.Count() > 0) {
                            rowCollect.First()["isSelect"] = true;
                            rowCollect.First()["idLinkPost"] = row["id"];
                        }
                    }
                    dtDeps.AcceptChanges();
                    dtDeps.DefaultView.Sort = "isSelect desc,name asc";
                    dtDeps = dtDeps.DefaultView.ToTable().Copy();
                }
                dgvData.DataSource = dtDeps;
            }
        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbNameDeps.Location = new Point(dgvData.Location.X, tbNameDeps.Location.Y);
            tbNameDeps.Size = new Size(cName.Width, tbNameDeps.Size.Height);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо заполнить \"{lName.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbName.Focus();
                return;
            }

            if (dtDeps == null) { MessageBox.Show("Нет данных по отдел.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (dtDeps.Rows.Count == 0) { MessageBox.Show("Нет данных по отделу.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
            if (rowCollect.Count() == 0) { MessageBox.Show("Необходимо выбрать отдел.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            
            Task<DataTable> task = Config.hCntMain.setPost(id, tbName.Text.Trim(), true, false, 0);
            task.Wait();

            DataTable dtResult = task.Result;

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((int)dtResult.Rows[0]["id"] == -1)
            {
                MessageBox.Show("В справочнике уже присутствует должность с таким наименованием.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

         
            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show("Произошла неведомая хрень.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id == 0)
            {
                id = (int)dtResult.Rows[0]["id"];
                Logging.StartFirstLevel(1);
                Logging.Comment("Добавить Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.Comment($"Наименование: {tbName.Text.Trim()}");
                Logging.StopFirstLevel();
            }
            else
            {
                Logging.StartFirstLevel(1);
                Logging.Comment("Редактировать Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.VariableChange("Наименование", tbName.Text.Trim(), oldName);
                Logging.StopFirstLevel();
            }

            foreach (int id in listDel)
            {
                task = Config.hCntMain.setPostLinkDep(id, 0, 0, true, true, 1);
                task.Wait();                
            }

            foreach (DataRow row in rowCollect)
            {
                task = Config.hCntMain.setPostLinkDep((int)row["idLinkPost"], (Int16)row["id"], id, true, false, 0);
                task.Wait();
            }


            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        List<int> listDel = new List<int>();
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = dtDeps.DefaultView[e.RowIndex]["isSelect"];
            var value_id = dtDeps.DefaultView[e.RowIndex]["idLinkPost"];
            if (value_id is int && value is bool)
            {
                if ((int)value_id != 0)
                {
                    if ((bool)value)
                    {
                        if (listDel.Contains((int)value_id))
                            listDel.Remove((int)value_id);
                    }
                    else
                    {
                        if (!listDel.Contains((int)value_id))
                            listDel.Add((int)value_id);
                    }

                }
            }
        }

        private void tbNameDeps_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void setFilter()
        {
            if (dtDeps == null || dtDeps.Rows.Count == 0)
            {                
                return;
            }

            try
            {
                string filter = "";

                if (tbNameDeps.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + string.Format("name like '%{0}%'", tbNameDeps.Text.Trim());

                dtDeps.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtDeps.DefaultView.RowFilter = "id = -1";
            }
            finally
            {                
            }
        }
    }
}

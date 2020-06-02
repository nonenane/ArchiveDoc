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
using Nwuram.Framework.Settings.User;

namespace ArchiveDocReport
{
    public partial class ctrReport : UserControl
    {
        private DataTable dtPostVsDeps, dtDepsLinkToDep;
        ArchiveDocSettings.LinkToProcedures linkToProcSettings = new ArchiveDocSettings.LinkToProcedures();

        public ctrReport()
        {
            InitializeComponent();
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            dgvData.AutoGenerateColumns = false;
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btPrint, "Печать");
            
        }

        private void ctrReport_Load(object sender, EventArgs e)
        {
            if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
                dtDepsLinkToDep = linkToProcSettings.getDepartmentsAccessView(UserSettings.User.IdDepartment);


            get_typeDoc();
            init_depsCombobox();
            init_postCombobox();
            init_postVsDeps();
        }

        private void init_depsCombobox()
        {
            DataTable dtDeps = null;
            Task<DataTable> task = Config.hCntMain.getDeps(true);
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0)
            { dtDeps = task.Result.Copy(); task = null; }

            if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
            {
                if (dtDepsLinkToDep == null)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == 0);
                    dtDeps = rowCollect.CopyToDataTable();
                }
                else
                {
                    DataTable dtTmp = dtDeps.Clone();

                    EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == 0);
                    dtTmp.Merge(rowCollect.CopyToDataTable());

                    foreach (DataRow row in dtDepsLinkToDep.Rows)
                    {
                        rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == (int)row["id_DepartmentsView"]);
                        if (rowCollect.Count() > 0)
                        {
                            dtTmp.ImportRow(rowCollect.First());
                        }
                    }

                    dtTmp.DefaultView.Sort = "isMain asc, name asc";
                    dtDeps = dtTmp.DefaultView.ToTable().Copy();
                }
            }

            cmbDeps.DataSource = dtDeps;
            cmbDeps.DisplayMember = "name";
            cmbDeps.ValueMember = "id";
        }

        private void init_postCombobox()
        {
            DataTable dtPost = null;
            Task<DataTable> task = Config.hCntMain.getPost(true);
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0)
            { dtPost = task.Result.Copy(); task = null; }

            cmbPost.DataSource = dtPost;
            cmbPost.DisplayMember = "cName";
            cmbPost.ValueMember = "id";
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }

        private void init_postVsDeps()
        {
            Task<DataTable> task = Config.hCntMain.getPostVsDeps();
            task.Wait();

            dtPostVsDeps = task.Result;

            if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
            {
                DataTable dtTmp = dtPostVsDeps.Clone();
                foreach (DataRow row in dtDepsLinkToDep.Rows)
                {
                    EnumerableRowCollection<DataRow> rowToReport = task.Result.AsEnumerable().Where(r => r.Field<int>("id_Departments") == (int)row["id_DepartmentsView"]);
                    if (rowToReport.Count() > 0)
                    {
                        dtTmp.Merge(rowToReport.CopyToDataTable());
                    }
                }

                dtPostVsDeps = dtTmp.Copy();
            }

            setFilter();
            dgvData.DataSource = dtPostVsDeps;
        }

        private void setFilter()
        {
            if (dtPostVsDeps == null || dtPostVsDeps.Rows.Count == 0)
            { //btSave.Enabled = false;
                return;
            }

            try
            {
                string filter = "";
                //if (tbNameDoc.Text.Trim().Length > 0)
                //  filter += (filter.Trim().Length > 0 ? " and " : "") + $"cName like '%{tbNameDoc.Text.Trim()}%' ";

                if ((int)cmbPost.SelectedValue != 0)
                    filter += (filter.Trim().Length > 0 ? " and " : "") + $"id_Posts  = {cmbPost.SelectedValue}";

                if (int.Parse(cmbDeps.SelectedValue.ToString()) != 0)
                    filter += (filter.Trim().Length > 0 ? " and " : "") + $"id_Departments  = {cmbDeps.SelectedValue}";

                dtPostVsDeps.DefaultView.RowFilter = filter;
                dtPostVsDeps.DefaultView.Sort = "nameDeps asc";
            }
            catch
            {
                dtPostVsDeps.DefaultView.RowFilter = "id = - 1";
            }
            finally
            {
                //btSave.Enabled = dtPostVsDeps.DefaultView.Count != 0;
            }
        }

        private void get_typeDoc()
        {
            Task<DataTable> task = Config.hCntMain.getTypeDoc(true);
            task.Wait();
            DataTable dtTypeDoc = null;
            if (task.Result != null && task.Result.Rows.Count > 0)
            {
                EnumerableRowCollection<DataRow> rowCollect = task.Result.AsEnumerable().Where(r => r.Field<bool>("isActive") && r.Field<bool>("ViewAdd"));
                if (rowCollect.Count() > 0)
                    dtTypeDoc = rowCollect.CopyToDataTable();
            }

            cmbTypeDoc.DataSource = dtTypeDoc;
            cmbTypeDoc.DisplayMember = "cName";
            cmbTypeDoc.ValueMember = "id";            
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            int id_typeDoc = (int)cmbTypeDoc.SelectedValue;
            EnumerableRowCollection<DataRow> rowCollect = dtPostVsDeps.AsEnumerable().Where(r => r.Field<bool>("isSelect"));

            if(!chbAllDepsAndPosts.Checked && rowCollect.Count()==0) { MessageBox.Show("Необходимо выбрать должность и отдел!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            Task<DataTable> task = Config.hCntMain.getReportInformationUser(id_typeDoc);
            task.Wait();

            if (task.Result == null || task.Result.Rows.Count == 0) { MessageBox.Show("Нет данных для отчёта!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);return; }

            DataTable dtReport = task.Result.Clone();

            if (!chbAllDepsAndPosts.Checked)
            {
                foreach (DataRow row in rowCollect)
                {
                    EnumerableRowCollection<DataRow> rowToReport = task.Result.AsEnumerable().Where(r => r.Field<int>("id_Departments") == (int)row["id_Departments"] && r.Field<int>("id_Posts") == (int)row["id_Posts"]);
                    if (rowToReport.Count() > 0)
                    {
                        dtReport.Merge(rowToReport.CopyToDataTable());
                    }
                }
            }
            else if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
            {
                foreach (DataRow row in dtDepsLinkToDep.Rows)
                {
                    EnumerableRowCollection<DataRow> rowToReport = task.Result.AsEnumerable().Where(r => r.Field<int>("id_Departments") == (int)row["id_DepartmentsView"]);
                    if (rowToReport.Count() > 0)
                    {
                        dtReport.Merge(rowToReport.CopyToDataTable());
                    }
                }
            }
            else
            {
                dtReport = task.Result.Copy();
            }

            if(dtReport.Rows.Count==0) { MessageBox.Show("Нет данных для отчёта!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();
            int indexRow = 1;
            int maxColumn = 5;

            report.Merge(indexRow, 1, indexRow, maxColumn);
            report.AddSingleValue("Документы, ожидающие ознакомления", indexRow, 1);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumn);
            report.SetFontBold(indexRow, 1, indexRow, maxColumn);
            report.SetFontSize(indexRow, 1, indexRow, maxColumn, 16);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, maxColumn);
            report.AddSingleValue($"Выгрузил:{Nwuram.Framework.Settings.User.UserSettings.User.FullUsername}", indexRow, 1);
            report.SetCellAlignmentToRight(indexRow, 1, indexRow, maxColumn);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, maxColumn);
            report.AddSingleValue($"Дата выгрузки:{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}", indexRow, 1);
            report.SetCellAlignmentToRight(indexRow, 1, indexRow, maxColumn);
            indexRow++;
            indexRow++;

            report.AddSingleValue("№", indexRow, 1);
            report.AddSingleValue("Отдел", indexRow, 2);
            report.AddSingleValue("Должность", indexRow, 3);
            report.AddSingleValue("Наименование документа", indexRow, 4);
            report.AddSingleValue("Дата отправки на ознакомление", indexRow, 5);
            report.SetBorders(indexRow, 1, indexRow, maxColumn);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumn);
            report.SetWrapText(indexRow, 1, indexRow, maxColumn);
            report.SetFontBold(indexRow, 1, indexRow, maxColumn);

            report.SetColumnWidth(indexRow, 1, indexRow, 1, 6);
            report.SetColumnWidth(indexRow, 2, indexRow, 2, 25);
            report.SetColumnWidth(indexRow, 3, indexRow, 3, 25);
            report.SetColumnWidth(indexRow, 4, indexRow, 4, 50);
            report.SetColumnWidth(indexRow, 5, indexRow, 5, 20);

            indexRow++;

            var groupDeps = dtReport.AsEnumerable().GroupBy(r => new { id_Departments = r.Field<int>("id_Departments"), nameDep = r.Field<string>("nameDep") })
                .Select(s => new
                {
                    s.Key.id_Departments,
                    s.Key.nameDep
                });

            int npp = 1;

            foreach (var gDep in groupDeps) 
            {
                int startIndexGroupDeps = indexRow;
                var groupPost = dtReport.AsEnumerable()
                    .Where(r=>r.Field<int>("id_Departments")==gDep.id_Departments)
                    .GroupBy(r => new { id_Posts = r.Field<int>("id_Posts"), namePost = r.Field<string>("namePost") })
                .Select(s => new
                {
                    s.Key.id_Posts,
                    s.Key.namePost
                });

                foreach (var gPost in groupPost)
                {
                    int startIndexGroupPost = indexRow;
                    rowCollect = dtReport.AsEnumerable()
                        .Where(r => r.Field<int>("id_Departments") == gDep.id_Departments && r.Field<int>("id_Posts") == gPost.id_Posts);

                    foreach (DataRow row in rowCollect)
                    {
                        report.AddSingleValue($"{npp}", indexRow, 1);
                        report.AddSingleValue($"{row["cName"]}", indexRow, 4);
                        report.AddSingleValue($"{((DateTime)row["DateEdit"]).ToShortDateString()}", indexRow, 5);
                        report.SetCellAlignmentToCenter(indexRow, 4, indexRow, 5);
                        report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
                        report.SetWrapText(indexRow, 4, indexRow, 4);
                        report.SetBorders(indexRow, 1, indexRow, 5);
                        indexRow++;
                        npp++;
                    }

                    report.Merge(startIndexGroupPost, 3, indexRow - 1, 3);
                    report.AddSingleValue($"{gPost.namePost}", startIndexGroupPost, 3);
                    report.SetCellAlignmentToCenter(startIndexGroupPost, 3, startIndexGroupPost, 3);
                    report.SetCellAlignmentToJustify(startIndexGroupPost, 3, startIndexGroupPost, 3);
                    report.SetWrapText(startIndexGroupPost, 3, startIndexGroupPost, 3);
                    report.SetBorders(startIndexGroupPost, 3, startIndexGroupPost, 3);
                }
                report.Merge(startIndexGroupDeps, 2, indexRow - 1, 2);
                report.AddSingleValue($"{gDep.nameDep.Trim()}", startIndexGroupDeps, 2);
                report.SetCellAlignmentToCenter(startIndexGroupDeps, 2, startIndexGroupDeps, 2);
                report.SetCellAlignmentToJustify(startIndexGroupDeps, 2, startIndexGroupDeps, 2);
                report.SetWrapText(startIndexGroupDeps, 2, startIndexGroupDeps, 2);
                report.SetBorders(startIndexGroupDeps, 2, startIndexGroupDeps, 2);
            }

            report.Show();
        }
    }
}

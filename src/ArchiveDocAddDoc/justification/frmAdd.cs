using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveDocAddDoc.justification
{
    public partial class frmAdd : Form
    {        
        public int id_Document { set; private get; }
        private DataTable dtPostVsDeps;
        public frmAdd()
        {
            InitializeComponent();
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);


            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
            dgvData.AutoGenerateColumns = false;
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.getPostVsDeps();
            task.Wait();

            dtPostVsDeps = task.Result;           
            //dgvData.DataSource = dtPostVsDeps;

            task = Config.hCntMain.getDocuments_vs_DepartmentsPosts(id_Document);
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0)
            {
                foreach (DataRow row in task.Result.Rows)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtPostVsDeps.AsEnumerable().Where(r => r.Field<int>("id") == (int)row["id_DepartmentsPosts"]);
                    if (rowCollect.Count() > 0)
                    {
                        //rowCollect.First()["isSelect"] = true;
                        rowCollect.First()["id_DocVsDepPosts"] = (int)row["id"];
                        rowCollect.First()["isBrowse"] = row["isBrowse"];
                        rowCollect.First()["id_Status"] = row["id_Status"];
                        rowCollect.First()["nameStatus"] = row["nameStatus"];
                    }
                }

                dtPostVsDeps.DefaultView.Sort = "isSelect desc, nameDeps asc, namePost asc";
                dtPostVsDeps.DefaultView.RowFilter = "id_DocVsDepPosts > 0 and id_Status = 3";
                dtPostVsDeps = dtPostVsDeps.DefaultView.ToTable().Copy();
                dgvData.DataSource = dtPostVsDeps;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbNumber.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо заполнить \"{lNumber.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNumber.Focus();
                return;
            }

            if (tbComment.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо заполнить \"{lComment.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbComment.Focus();
                return;
            }

            if (dtPostVsDeps == null) { MessageBox.Show("Нет данных по должностям.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (dtPostVsDeps.Rows.Count == 0) { MessageBox.Show("Нет данных по должностям.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            EnumerableRowCollection<DataRow> rowCollect = dtPostVsDeps.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
            if (rowCollect.Count() == 0) { MessageBox.Show("Необходимо выбрать должность.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            foreach (DataRow row in rowCollect)
            {
                Task<DataTable> task = Config.hCntMain.setDocuments_vs_DepartmentsPosts((int)row["id_DocVsDepPosts"], tbComment.Text, tbNumber.Text, (int)row["id"], id_Document, 4, (bool)row["isBrowse"], false, 0);
                task.Wait();
            }

            //DataTable dtResult = null;// = task.Result;

            //if (dtResult == null || dtResult.Rows.Count == 0)
            //{
            //    MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if ((int)dtResult.Rows[0]["id"] == -9999)
            //{
            //    MessageBox.Show("Произошла неведомая хрень.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = DialogResult.OK != this.DialogResult;
        }
    }
}

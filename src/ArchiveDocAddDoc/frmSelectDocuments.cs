using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveDocAddDoc
{
    public partial class frmSelectDocuments : Form
    {

        private docInfo docInfo;
        private DataTable dtData;
        public docInfo setDocInfo() { return docInfo; }

        public frmSelectDocuments()
        {            
            InitializeComponent();

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");            

            docInfo = new docInfo();
            dgvData.AutoGenerateColumns = false;
        }

        private void frmSelectDocuments_Load(object sender, EventArgs e)
        {
            init_depsCombobox();
            init_postCombobox();
            getData();
        }

        private void init_depsCombobox()
        {
            DataTable dtDeps = null;
            Task<DataTable> task = Config.hCntMain.getDeps(true);
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0)
            { dtDeps = task.Result.Copy(); task = null; }

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

        private void getData()
        {
            Task<DataTable> task = Config.hCntMain.getDocumentsForAdd();
            task.Wait();
            dtData = task.Result;
            setFilter();
            dgvData.DataSource = dtData;
        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbNameDoc.Location = new Point(dgvData.Location.X + cType.Width + 1, tbNameDoc.Location.Y);
            tbNameDoc.Size = new Size(cNameDoc.Width, tbNameDoc.Size.Height);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || !btSave.Enabled) return;
            btSave_Click(null, null);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null) return;
            if (dgvData.CurrentRow.Index == -1) return;

            int indexRow = dgvData.CurrentRow.Index;

            docInfo.nameDoc = (string)dtData.DefaultView[indexRow]["cName"];
            docInfo.fileName = (string)dtData.DefaultView[indexRow]["FileName"];
            docInfo.fileNameWithOutExtension = Path.GetFileNameWithoutExtension((string)dtData.DefaultView[indexRow]["FileName"]);
            docInfo.id_doc = (int)dtData.DefaultView[indexRow]["id"];

            this.DialogResult = DialogResult.OK;
        }

        private void tbNameDoc_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void setFilter() 
        {
            if (dtData == null || dtData.Rows.Count == 0) { btSave.Enabled = false;return; }

            try
            {
                string filter = "";
                if(tbNameDoc.Text.Trim().Length>0)
                    filter+= (filter.Trim().Length>0? " and ":"")+$"cName like '%{tbNameDoc.Text.Trim()}%' ";

                if ((int)cmbPost.SelectedValue != 0)
                    filter += (filter.Trim().Length > 0 ? " and " : "") + $"id_Posts  = {cmbPost.SelectedValue}";

                if (int.Parse(cmbDeps.SelectedValue.ToString()) != 0)
                    filter += (filter.Trim().Length > 0 ? " and " : "") + $"id_Departments  = {cmbDeps.SelectedValue}";

                dtData.DefaultView.RowFilter = filter;
                dtData.DefaultView.Sort = "cName asc";
            }
            catch {
                dtData.DefaultView.RowFilter = "id = - 1";
            }
            finally {
                btSave.Enabled = dtData.DefaultView.Count != 0;
            }
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }
    }
}

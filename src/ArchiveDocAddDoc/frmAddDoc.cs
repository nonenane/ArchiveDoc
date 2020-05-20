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

namespace ArchiveDocAddDoc
{
    public partial class frmAddDoc : Form
    {
        public DataRowView row { set; private get; }

        private bool isEditData = false;
        private string oldName, oldNpp;
        private bool oldViewAdd, oldViewArchive;
        private int id = 0;

        public frmAddDoc()
        {
            InitializeComponent();
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            get_typeDoc();
        }

        private void frmAddDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void get_typeDoc()
        {
            Task<DataTable> task = Config.hCntMain.getTypeDoc();
            task.Wait();
            DataTable dtTypeDoc = task.Result;
            if (dtTypeDoc != null && dtTypeDoc.Rows.Count > 0)
                dtTypeDoc = dtTypeDoc.AsEnumerable().Where(r => r.Field<bool>("isActive")).CopyToDataTable();

            cmbTypeDoc.DataSource = dtTypeDoc;
            cmbTypeDoc.DisplayMember = "cName";
            cmbTypeDoc.ValueMember = "id";
            cmbTypeDoc.SelectedIndex = -1;
        }

    }
}

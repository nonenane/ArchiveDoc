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

namespace ArchiveDocJournalStatusHistory
{
    public partial class frmHistory : Form
    {
        public int id_DocumentsDepartmentsPosts { set; private get; }

        public frmHistory()
        {
            InitializeComponent();

            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            dgvData.AutoGenerateColumns = false;

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.getHistoryStatus(id_DocumentsDepartmentsPosts);
            task.Wait();
            dgvData.DataSource = task.Result;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveDoc
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ArchiveDocaTypeDoc.frmList().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ArchiveDocAddDoc.frmAddDoc() { Text = "Добавление документа" }.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new post.frmAdd() { Text = "Добавить должность" }.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new ArchiveDocJournalStatusHistory.frmHistory() { id_DocumentsDepartmentsPosts = 4 }.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new ArchiveDocExtensionsFile.frmList().ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //panel1.Controls.Add(new ArchiveDocSettings.settings() {Dock =DockStyle.Fill });
            //panel1.Controls.Add(new ArchiveDocReport.ctrReport() { Dock = DockStyle.Fill });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ArchiveDocSettings.settings() { Dock = DockStyle.Fill });

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ArchiveDocReport.ctrReport() { Dock = DockStyle.Fill });
        }
    }
}

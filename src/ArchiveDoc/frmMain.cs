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
            tsslServerDataBase.Text = $"Сервер: {Nwuram.Framework.Settings.Connection.ConnectionSettings.GetServer()}; База данных: {Nwuram.Framework.Settings.Connection.ConnectionSettings.GetDatabase()};";
            this.Text = $"Программа: {Nwuram.Framework.Settings.Connection.ConnectionSettings.ProgramName};" +
                //$" Должность: {Nwuram.Framework.Settings.User.UserSettings.User.Status};" +
                $" Пользователь: {Nwuram.Framework.Settings.User.UserSettings.User.FullUsername}";

        }
   
        private void button3_Click(object sender, EventArgs e)
        {
            //new post.frmAdd() { Text = "Добавить должность" }.ShowDialog();
        }
     
        private void frmMain_Load(object sender, EventArgs e)
        {           
            tabControl1.TabPages.Remove(tabPage1);
            ImageList listTabPage = new ImageList();
            listTabPage.ImageSize = new Size(32, 32);
            listTabPage.Images.Add("Document", Properties.Resources.Folder);
            listTabPage.Images.Add("Settings", Properties.Resources.settings);
            listTabPage.Images.Add("Report", Properties.Resources.monitor);

            tabControl1.ImageList = listTabPage;

            tpMain.ImageKey = "Document";
            tpSettings.ImageKey = "Settings";
            tpReport.ImageKey = "Report";
            //panel1.Controls.Add(new ArchiveDocSettings.settings() {Dock =DockStyle.Fill });
            //panel1.Controls.Add(new ArchiveDocReport.ctrReport() { Dock = DockStyle.Fill });
            if (Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower().Equals("ркв"))
                tpMain.Controls.Add(new cntDocumentsRKV() { Dock = DockStyle.Fill });
            else
                tpMain.Controls.Add(new cntDocuments() { Dock = DockStyle.Fill });

            if (Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower().Equals("ркв"))
                tabControl1.TabPages.Remove(tpSettings);


            tpSettings.Controls.Add(new ArchiveDocSettings.settings() { Dock = DockStyle.Fill });
            tpReport.Controls.Add(new ArchiveDocReport.ctrReport() { Dock = DockStyle.Fill });
        }
     
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show(Config.centralText("Вы действительно хотите выйти\nиз программы?\n"), "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No;
        }
    }
}

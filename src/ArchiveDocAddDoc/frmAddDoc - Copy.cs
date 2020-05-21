using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveDocAddDoc
{
    public partial class frmAddDoc_copy : Form
    {
        public DataRowView row { set; private get; }

        private bool isEditData = false;
        private string oldName, oldNpp;
        private bool oldViewAdd, oldViewArchive;
        private int id = 0;
        private string fileName="";
        private byte[] fileBytes=null;
        public frmAddDoc_copy()
        {
            InitializeComponent();
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");

            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.FilterIndex = 2;
            openFileDialog1.FileName = "";
            openFileDialog1.RestoreDirectory = true;

            this.rbPC.AutoCheck = false;
            this.rbDataBase.AutoCheck = false;
            this.rbPC.Click += new System.EventHandler(this.checkBox1_Click);
            this.rbDataBase.Click += new System.EventHandler(this.checkBox1_Click);

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            get_typeDoc();
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {
            if (rbPC.Checked)
            {
                openFileDialog1.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF|Text files(*.txt)|*.txt|All files(*.*)|*.*";
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {
                    fileName =  Path.GetFileName(openFileDialog1.FileName);
                    string fileNameWithOutExtension = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    fileBytes = File.ReadAllBytes(openFileDialog1.FileName);
                    tbFileName.Text = fileNameWithOutExtension;
                }
            }
            else if (rbDataBase.Checked)
            {
                frmSelectDocuments frmSelDoc = new frmSelectDocuments() { Text = "Выбрать документ" };
                if (DialogResult.OK == frmSelDoc.ShowDialog())
                {
                    frmSelDoc.setDocInfo();
                }
            }
        }

        private void frmAddDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cmbTypeDoc.SelectedIndex==-1)
            {
                MessageBox.Show($"Необходимо заполнить \"{lTypeDoc.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTypeDoc.Focus();
                return;
            }

            if (fileBytes==null)
            {
                MessageBox.Show($"Необходимо выбрать \"{lFileName.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btAddDoc.Focus();
                return;
            }

            if (tbNameDoc.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо заполнить \"{lNameDoc.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNameDoc.Focus();
                return;
            }



            Task<DataTable> task = Config.hCntMain.setDocuments(id, tbNameDoc.Text.Trim(), tbFileName.Text, fileBytes, (int)cmbTypeDoc.SelectedValue, false, 0);
            task.Wait();

            DataTable dtResult = task.Result;

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((int)dtResult.Rows[0]["id"] == -1)
            {
                MessageBox.Show("В базе данных уже присутствует документ с таким наименованием. Сохранение не возможно.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Logging.Comment($"Наименование: {tbNameDoc.Text.Trim()}");
                //Logging.Comment($"Номер по порядку: {tbNpp.Text.Trim()}");
                //Logging.Comment($"Отображение архивных документов у руководителя: {(chbViewArchive.Checked ? "Да" : "Нет")}");
                //Logging.Comment($"Отображать при добавлении документа: {(chbViewAdd.Checked ? "Да" : "Нет")}");
                Logging.StopFirstLevel();
            }
            else
            {
                Logging.StartFirstLevel(1);
                Logging.Comment("Редактировать Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.VariableChange("Наименование", tbNameDoc.Text.Trim(), oldName);
                //Logging.VariableChange("Номер по порядку", tbNpp.Text.Trim(), oldNpp);
                //Logging.VariableChange($"Отображение архивных документов у руководителя:", (chbViewArchive.Checked ? "Да" : "Нет"), (oldViewArchive ? "Да" : "Нет"));
                //Logging.VariableChange($"Отображать при добавлении документа:", (chbViewAdd.Checked ? "Да" : "Нет"), (oldViewAdd ? "Да" : "Нет"));

                Logging.StopFirstLevel();
            }


            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void get_typeDoc()
        {
            Task<DataTable> task = Config.hCntMain.getTypeDoc();
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
            cmbTypeDoc.SelectedIndex = -1;
        }


        private void checkBox1_Click(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            string rbName = radioButton.Name;

            if (!radioButton.Checked)
            {
                DialogResult dialogResult = DialogResult.Yes;

                if (fileBytes != null)
                {
                    dialogResult = MessageBox.Show(
                        "Есть данные?", "Смена",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (dialogResult == DialogResult.Yes)
                {
                    fileName = "";
                    fileBytes = null;
                    tbFileName.Text = "";
                    //radioButton.Checked = true;
                    if (rbName.Equals(rbDataBase.Name)) { radioButton.Checked = true; rbPC.Checked = false; }
                    else if (rbName.Equals(rbPC.Name)) { radioButton.Checked = true; rbDataBase.Checked = false; }
                }
            }
            //else
            //{
            //    radioButton.Checked = false;
            //}
        }

    }
}

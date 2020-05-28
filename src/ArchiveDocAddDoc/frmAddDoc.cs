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
    public partial class frmAddDoc : Form
    {
        //public DataRowView row { set; private get; }
        public int id { set; private get; }

        private bool isEditData = false;
        private string oldName, oldNpp;
        private bool oldViewAdd, oldViewArchive;
        
        private string fileName="";
        private byte[] fileBytes=null;
        DataTable dtPostVsDeps;
        public frmAddDoc()
        {
            InitializeComponent();
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
            tp.SetToolTip(btAddDoc, "Добавить документ");

            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.FilterIndex = 2;
            openFileDialog1.FileName = "";
            openFileDialog1.RestoreDirectory = true;

            this.rbPC.AutoCheck = false;
            this.rbDataBase.AutoCheck = false;
            this.rbPC.Click += new System.EventHandler(this.checkBox1_Click);
            this.rbDataBase.Click += new System.EventHandler(this.checkBox1_Click);
            
            dgvData.AutoGenerateColumns = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            get_typeDoc();
            init_depsCombobox();
            init_postCombobox();
            init_postVsDeps();
            init_extentsion();

            if (id != 0)
            {
                Task<DataTable> task = Config.hCntMain.getDocuments(id);
                task.Wait();
                if (task.Result != null && task.Result.Rows.Count > 0)
                {
                    cmbTypeDoc.SelectedValue = (int)task.Result.Rows[0]["id_TypeDoc"];
                    tbNameDoc.Text = (string)task.Result.Rows[0]["cName"];
                    tbFileName.Text = Path.GetFileNameWithoutExtension((string)task.Result.Rows[0]["FileName"]);
                    fileName = (string)task.Result.Rows[0]["FileName"];

                    task = Config.hCntMain.getDocuments_vs_DepartmentsPosts(id);
                    task.Wait();
                    if (task.Result != null && task.Result.Rows.Count > 0)
                    {
                        foreach (DataRow row in task.Result.Rows)
                        {
                            EnumerableRowCollection<DataRow> rowCollect = dtPostVsDeps.AsEnumerable().Where(r => r.Field<int>("id") == (int)row["id_DepartmentsPosts"]);
                            if (rowCollect.Count() > 0)
                            {
                                rowCollect.First()["isSelect"] = true;
                                rowCollect.First()["id_DocVsDepPosts"] = (int)row["id"];
                            }
                        }
                    }
                }
            }
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {
            if (rbPC.Checked)
            {                
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
                    docInfo dInfo = frmSelDoc.setDocInfo();

                    fileName = dInfo.fileName;
                    tbFileName.Text = dInfo.nameDoc;
                    fileBytes = dInfo.fileBytes;
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

            if (fileBytes == null && id == 0)
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

            if (dtPostVsDeps == null) { MessageBox.Show("Нет данных по должностям.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (dtPostVsDeps.Rows.Count == 0) { MessageBox.Show("Нет данных по должностям.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            EnumerableRowCollection<DataRow> rowCollect = dtPostVsDeps.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
            if (rowCollect.Count() == 0) { MessageBox.Show("Необходимо выбрать должность.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }



            MessageBoxManager.Unregister();
            MessageBoxManager.Yes = "Новый";
            MessageBoxManager.No= "Ознакомление";
            MessageBoxManager.Cancel = "Отмена";
            MessageBoxManager.Register();
            DialogResult dlgResult = MessageBox.Show("Выберите статус добавляемого документа:", "Добавление документа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            MessageBoxManager.Unregister();

            if (DialogResult.Cancel == dlgResult) return;
            int id_status = 1;
            if (DialogResult.No == dlgResult) id_status = 2;

            Task<DataTable> task = Config.hCntMain.setDocuments(id, tbNameDoc.Text.Trim(), fileName, fileBytes, (int)cmbTypeDoc.SelectedValue, false, 0);
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

            if ((int)dtResult.Rows[0]["id"] == -2)
            {
                MessageBox.Show(Config.centralText("Нет возможности сменить статус\nне соответствие условию смены\n!"), "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            foreach (int id_DocVsDepPosts in listDelPost)
            {
                task = Config.hCntMain.setDocuments_vs_DepartmentsPosts(id_DocVsDepPosts, "", "", 0, id, id_status, false, true, 1);
                task.Wait();
            }

            foreach (DataRow row in rowCollect)
            {
                task = Config.hCntMain.setDocuments_vs_DepartmentsPosts((int)row["id_DocVsDepPosts"], "", "", (int)row["id"], id, id_status, false, false, 0);
                task.Wait();
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
                    if (rbName.Equals(rbDataBase.Name)) { radioButton.Checked = true; rbPC.Checked = false; }// btAddDoc.Enabled = false; }
                    else if (rbName.Equals(rbPC.Name)) { radioButton.Checked = true; rbDataBase.Checked = false; }// btAddDoc.Enabled = true; }
                }
            }
            //else
            //{
            //    radioButton.Checked = false;
            //}
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

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }

        private void init_postVsDeps()
        {
            Task<DataTable> task = Config.hCntMain.getPostVsDeps();
            task.Wait();

            dtPostVsDeps = task.Result;
            setFilter();
            dgvData.DataSource = dtPostVsDeps;
        }

        private List<int> listDelPost = new List<int>();
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cSelect.Index)
            {
                if (dtPostVsDeps.DefaultView[e.RowIndex]["isSelect"] is bool && dtPostVsDeps.DefaultView[e.RowIndex]["id_DocVsDepPosts"] is int)
                {
                    int id_DocVsDepPosts = (int)dtPostVsDeps.DefaultView[e.RowIndex]["id_DocVsDepPosts"];
                    bool isSelect = (bool)dtPostVsDeps.DefaultView[e.RowIndex]["isSelect"];

                    if (id_DocVsDepPosts == 0) return;

                    if (isSelect) { if (listDelPost.Contains(id_DocVsDepPosts)) listDelPost.Remove(id_DocVsDepPosts); }
                    else
                    { if (!listDelPost.Contains(id_DocVsDepPosts)) listDelPost.Add(id_DocVsDepPosts); }
                }
            }
        }

        private void setFilter()
        {
            if (dtPostVsDeps == null || dtPostVsDeps.Rows.Count == 0) { //btSave.Enabled = false;
                return; }

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

        private void init_extentsion()
        {
            Task<DataTable> task = Config.hCntMain.getTypeFile();
            task.Wait();

            if (task.Result == null || task.Result.Rows.Count == 0)
                //openFileDialog1.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF|Text files(*.txt)|*.txt|All files(*.*)|*.*";
                openFileDialog1.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            else
            {
                var groupeExtension = task.Result.AsEnumerable()
                        .Where(r=>r.Field<bool>("isActive") && r.Field<bool>("isUse"))
                        .GroupBy(r => new { id_GroupFile = r.Field<int>("id_GroupFile"), cName = r.Field<string>("cName") })
                        .Select(s => new
                        {
                            s.Key.cName,
                            s.Key.id_GroupFile
                        });

                string filterExtension = "";

                foreach (var gGroup in groupeExtension)
                {
                    filterExtension += $"{gGroup.cName}|";
                    EnumerableRowCollection<DataRow> rowCollect = task.Result.AsEnumerable().Where(r => r.Field<int>("id_GroupFile") == gGroup.id_GroupFile && r.Field<bool>("isActive") && r.Field<bool>("isUse"));
                    foreach (DataRow row in rowCollect)
                    {
                        filterExtension += $"*.{row["Extension"]};";
                    }
                    filterExtension = filterExtension.Remove(filterExtension.Length - 1, 1);
                    filterExtension += "|";
                }
                filterExtension = filterExtension.Remove(filterExtension.Length - 1, 1);
                openFileDialog1.Filter = filterExtension;
            }
        }
    }
}

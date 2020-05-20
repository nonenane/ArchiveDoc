using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveDocaTypeDoc
{
    public partial class frmAdd : Form
    {
        public DataRowView row { set; private get; }


        private bool isEditData = false;
        private string oldName, oldNpp;
        private bool oldViewAdd, oldViewArchive;
        private int id = 0;

        public frmAdd()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            if (row != null)
            {
                id = (int)row["id"];
                tbName.Text = (string)row["cName"];
                tbNpp.Text = row["npp"].ToString();
                chbViewAdd.Checked = (bool)row["ViewAdd"];
                chbViewArchive.Checked = (bool)row["ViewArchive"];

                oldName = tbName.Text.Trim();
                oldNpp = tbNpp.Text.Trim();
                oldViewAdd = chbViewAdd.Checked;
                oldViewArchive = chbViewArchive.Checked;
            }

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

        private void tbNpp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbNpp.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо заполнить \"{lNpp.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNpp.Focus();
                return;
            }

            if (tbName.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо заполнить \"{lName.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbName.Focus();
                return;
            }

            int npp = int.Parse(tbNpp.Text);

            Task<DataTable> task = Config.hCntMain.setTypeDoc(id, tbName.Text.Trim(), npp, chbViewAdd.Checked, chbViewArchive.Checked, true, false, 0);
            task.Wait();

            DataTable dtResult = task.Result;

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((int)dtResult.Rows[0]["id"] == -1)
            {
                MessageBox.Show("В справочнике уже присутствует тип документа с таким наименованием.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -2)
            {
                MessageBox.Show("В справочнике уже занят указанный Вами номер по порядку.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Logging.Comment($"Номер по порядку: {tbNpp.Text.Trim()}");
                Logging.Comment($"Отображение архивных документов у руководителя: {(chbViewArchive.Checked?"Да":"Нет")}");
                Logging.Comment($"Отображать при добавлении документа: {(chbViewAdd.Checked ? "Да" : "Нет")}");
                Logging.StopFirstLevel();
            }
            else
            {
                Logging.StartFirstLevel(1);
                Logging.Comment("Редактировать Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.VariableChange("Наименование", tbName.Text.Trim(), oldName);
                Logging.VariableChange("Номер по порядку", tbNpp.Text.Trim(), oldNpp);
                Logging.VariableChange($"Отображение архивных документов у руководителя:", (chbViewArchive.Checked ? "Да" : "Нет"), (oldViewArchive ? "Да" : "Нет"));
                Logging.VariableChange($"Отображать при добавлении документа:", (chbViewAdd.Checked ? "Да" : "Нет"), (oldViewAdd ? "Да" : "Нет"));

                Logging.StopFirstLevel();
            }


            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }
    }
}

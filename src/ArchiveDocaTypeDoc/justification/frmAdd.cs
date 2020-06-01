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

namespace ArchiveDocaTypeDoc.justification
{
    public partial class frmAdd : Form
    {
        public int id_TypeDoc { set; private get; }        
        public frmAdd()
        {
            InitializeComponent();
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

        }

        private void frmAdd_Load(object sender, EventArgs e)
        {

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

            Task<DataTable> task = Config.hCntMain.setJustification(id_TypeDoc, tbComment.Text,tbNumber.Text);
            task.Wait();

            DataTable dtResult = task.Result;

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show("Произошла неведомая хрень.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = DialogResult.OK != this.DialogResult;
        }
    }
}

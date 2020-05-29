using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace MyMessageBox
{
    public partial class MyMessageBox : Form
    {

        private MessageBoxButtons messageBoxButtons;
        private List<string> listButtonName;
        public MyMessageBox(string textBody, string textTitle, MessageBoxButtons messageBoxButtons,List<string> listButtonName)
        {
            InitializeComponent();
            this.messageBoxButtons = messageBoxButtons;
            this.listButtonName = listButtonName;
            label1.Text = textBody;
            this.Text = textTitle;

            createButtons();
            
        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void createButtons()
        {

            if (messageBoxButtons == MessageBoxButtons.OK)
            {
                Button bt = new Button();
                bt.Click += (sender, e) => { this.DialogResult = DialogResult.Yes; };
                bt.Text = listButtonName[0];
                bt.AutoSize = true;
                bt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
                bt.Location = new Point(12, 116);
                this.flowLayoutPanel1.Controls.Add(bt);
                return;
            }
            if (messageBoxButtons == MessageBoxButtons.YesNo)
            {
                Button bt = new Button();
                bt.Click += (sender, e) => { this.DialogResult = DialogResult.No; };
                //bt.Text = "sfhdsfhd\njfhkjf222464\n64545646456\n22223g";
                bt.Text = listButtonName[1];
                bt.AutoSize = true;
                bt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
                bt.Location = new Point(12, 116);
                this.flowLayoutPanel1.Controls.Add(bt);

                int wi = bt.Width;

                bt = new Button();
                bt.Click += (sender, e) => { this.DialogResult = DialogResult.Yes; };
                bt.Text = listButtonName[0];
                bt.AutoSize = true;
                bt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
                bt.Location = new Point(12+ wi+10, 116);
                this.flowLayoutPanel1.Controls.Add(bt);
                return;                
            }

            if (messageBoxButtons == MessageBoxButtons.YesNoCancel)
            {

                Button bt = new Button();
                bt.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; };
                bt.Text = listButtonName[2];
                //bt.Text = "sfsfssf";
                bt.AutoSize = true;
                bt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
                bt.Location = new Point(12, 116);
                this.flowLayoutPanel1.Controls.Add(bt);

                int wi = bt.Location.X + bt.Width;

                bt = new Button();
                bt.Click += (sender, e) => { this.DialogResult = DialogResult.No; };
                bt.Text = listButtonName[1];
                bt.AutoSize = true;
                bt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
                bt.Location = new Point(12 + wi + 10, 116);
                this.flowLayoutPanel1.Controls.Add(bt);

                wi = bt.Location.X + bt.Width;

                bt = new Button();
                bt.Click += (sender, e) => { this.DialogResult = DialogResult.Yes; };
                bt.Text = listButtonName[0];
                bt.AutoSize = true;
                bt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
                bt.Location = new Point(wi + 10, 116);
                this.flowLayoutPanel1.Controls.Add(bt);

                return;
            }
        }
    }

    public enum MessageBoxButtons
    {
        OK,
        YesNo,
        //OKCancel,
        //AbortRetryIgnore,
        YesNoCancel,
        //YesNo,
        //RetryCancel
    }
}

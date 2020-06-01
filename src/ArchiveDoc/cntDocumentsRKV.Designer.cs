namespace ArchiveDoc
{
    partial class cntDocumentsRKV
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chbUnActivePost = new System.Windows.Forms.CheckBox();
            this.trvDeps = new System.Windows.Forms.TreeView();
            this.trvPost = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNameDocuments = new System.Windows.Forms.TextBox();
            this.tbNamePosts = new System.Windows.Forms.TextBox();
            this.tbNameDeps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pUnActivePost = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pViewDoc = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перевестиДокументВАрхивToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьНаСтатусНаОзнакомленииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отозватьСнаОзнакомленииНановыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналСменыСтатусовДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btNext = new System.Windows.Forms.Button();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.btDropFilter = new System.Windows.Forms.Button();
            this.btFilter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbUnActivePost
            // 
            this.chbUnActivePost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUnActivePost.AutoSize = true;
            this.chbUnActivePost.Location = new System.Drawing.Point(47, 626);
            this.chbUnActivePost.Name = "chbUnActivePost";
            this.chbUnActivePost.Size = new System.Drawing.Size(165, 17);
            this.chbUnActivePost.TabIndex = 0;
            this.chbUnActivePost.Text = "недействующая должность";
            this.chbUnActivePost.UseVisualStyleBackColor = true;
            this.chbUnActivePost.CheckedChanged += new System.EventHandler(this.chbUnActivePost_CheckedChanged);
            // 
            // trvDeps
            // 
            this.trvDeps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvDeps.Location = new System.Drawing.Point(20, 139);
            this.trvDeps.Name = "trvDeps";
            this.trvDeps.Size = new System.Drawing.Size(382, 467);
            this.trvDeps.TabIndex = 2;
            this.trvDeps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.trvDeps.Validating += new System.ComponentModel.CancelEventHandler(this.trvDeps_Validating);
            // 
            // trvPost
            // 
            this.trvPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvPost.Location = new System.Drawing.Point(408, 139);
            this.trvPost.Name = "trvPost";
            this.trvPost.Size = new System.Drawing.Size(499, 467);
            this.trvPost.TabIndex = 3;
            this.trvPost.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvPost_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btDropFilter);
            this.groupBox1.Controls.Add(this.btFilter);
            this.groupBox1.Controls.Add(this.tbNameDocuments);
            this.groupBox1.Controls.Add(this.tbNamePosts);
            this.groupBox1.Controls.Add(this.tbNameDeps);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 130);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // tbNameDocuments
            // 
            this.tbNameDocuments.Location = new System.Drawing.Point(87, 84);
            this.tbNameDocuments.Name = "tbNameDocuments";
            this.tbNameDocuments.Size = new System.Drawing.Size(251, 20);
            this.tbNameDocuments.TabIndex = 1;
            // 
            // tbNamePosts
            // 
            this.tbNamePosts.Location = new System.Drawing.Point(87, 56);
            this.tbNamePosts.Name = "tbNamePosts";
            this.tbNamePosts.Size = new System.Drawing.Size(251, 20);
            this.tbNamePosts.TabIndex = 1;
            // 
            // tbNameDeps
            // 
            this.tbNameDeps.Location = new System.Drawing.Point(87, 28);
            this.tbNameDeps.Name = "tbNameDeps";
            this.tbNameDeps.Size = new System.Drawing.Size(251, 20);
            this.tbNameDeps.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "по документу";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "по должности";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "по отделу";
            // 
            // pUnActivePost
            // 
            this.pUnActivePost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pUnActivePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.pUnActivePost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pUnActivePost.Location = new System.Drawing.Point(22, 625);
            this.pUnActivePost.Name = "pUnActivePost";
            this.pUnActivePost.Size = new System.Drawing.Size(19, 19);
            this.pUnActivePost.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 628);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "на ознакомлении";
            // 
            // pViewDoc
            // 
            this.pViewDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pViewDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pViewDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pViewDoc.Location = new System.Drawing.Point(410, 625);
            this.pViewDoc.Name = "pViewDoc";
            this.pViewDoc.Size = new System.Drawing.Size(19, 19);
            this.pViewDoc.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.документToolStripMenuItem,
            this.перевестиДокументВАрхивToolStripMenuItem,
            this.сменитьНаСтатусНаОзнакомленииToolStripMenuItem,
            this.отозватьСнаОзнакомленииНановыйToolStripMenuItem,
            this.журналСменыСтатусовДокументовToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(312, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // документToolStripMenuItem
            // 
            this.документToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.документToolStripMenuItem.Name = "документToolStripMenuItem";
            this.документToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.документToolStripMenuItem.Text = "Документ";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // перевестиДокументВАрхивToolStripMenuItem
            // 
            this.перевестиДокументВАрхивToolStripMenuItem.Name = "перевестиДокументВАрхивToolStripMenuItem";
            this.перевестиДокументВАрхивToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.перевестиДокументВАрхивToolStripMenuItem.Text = "Перевести документ в архив";
            this.перевестиДокументВАрхивToolStripMenuItem.Click += new System.EventHandler(this.перевестиДокументВАрхивToolStripMenuItem_Click);
            // 
            // сменитьНаСтатусНаОзнакомленииToolStripMenuItem
            // 
            this.сменитьНаСтатусНаОзнакомленииToolStripMenuItem.Name = "сменитьНаСтатусНаОзнакомленииToolStripMenuItem";
            this.сменитьНаСтатусНаОзнакомленииToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.сменитьНаСтатусНаОзнакомленииToolStripMenuItem.Text = "Сменить на статус «На ознакомлении»";
            this.сменитьНаСтатусНаОзнакомленииToolStripMenuItem.Click += new System.EventHandler(this.сменитьНаСтатусНаОзнакомленииToolStripMenuItem_Click);
            // 
            // отозватьСнаОзнакомленииНановыйToolStripMenuItem
            // 
            this.отозватьСнаОзнакомленииНановыйToolStripMenuItem.Name = "отозватьСнаОзнакомленииНановыйToolStripMenuItem";
            this.отозватьСнаОзнакомленииНановыйToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.отозватьСнаОзнакомленииНановыйToolStripMenuItem.Text = "Отозвать с «на ознакомлении» на «новый»";
            this.отозватьСнаОзнакомленииНановыйToolStripMenuItem.Click += new System.EventHandler(this.отозватьСнаОзнакомленииНановыйToolStripMenuItem_Click);
            // 
            // журналСменыСтатусовДокументовToolStripMenuItem
            // 
            this.журналСменыСтатусовДокументовToolStripMenuItem.Name = "журналСменыСтатусовДокументовToolStripMenuItem";
            this.журналСменыСтатусовДокументовToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.журналСменыСтатусовДокументовToolStripMenuItem.Text = "Журнал смены статусов документов";
            this.журналСменыСтатусовДокументовToolStripMenuItem.Click += new System.EventHandler(this.журналСменыСтатусовДокументовToolStripMenuItem_Click);
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.BackgroundImage = global::ArchiveDoc.Properties.Resources.like;
            this.btNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btNext.Location = new System.Drawing.Point(911, 562);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(44, 44);
            this.btNext.TabIndex = 7;
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btOpenFile
            // 
            this.btOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenFile.BackgroundImage = global::ArchiveDoc.Properties.Resources.click;
            this.btOpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btOpenFile.Location = new System.Drawing.Point(911, 139);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(44, 44);
            this.btOpenFile.TabIndex = 7;
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // btDropFilter
            // 
            this.btDropFilter.BackgroundImage = global::ArchiveDoc.Properties.Resources.filter_drop;
            this.btDropFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btDropFilter.Location = new System.Drawing.Point(344, 72);
            this.btDropFilter.Name = "btDropFilter";
            this.btDropFilter.Size = new System.Drawing.Size(32, 32);
            this.btDropFilter.TabIndex = 7;
            this.btDropFilter.UseVisualStyleBackColor = true;
            this.btDropFilter.Click += new System.EventHandler(this.btDropFilter_Click);
            // 
            // btFilter
            // 
            this.btFilter.BackgroundImage = global::ArchiveDoc.Properties.Resources.search;
            this.btFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btFilter.Location = new System.Drawing.Point(344, 28);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(32, 32);
            this.btFilter.TabIndex = 7;
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // cntDocumentsRKV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pViewDoc);
            this.Controls.Add(this.pUnActivePost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btOpenFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trvPost);
            this.Controls.Add(this.trvDeps);
            this.Controls.Add(this.chbUnActivePost);
            this.Name = "cntDocumentsRKV";
            this.Size = new System.Drawing.Size(960, 662);
            this.Load += new System.EventHandler(this.cntDocuments_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbUnActivePost;
        private System.Windows.Forms.TreeView trvDeps;
        private System.Windows.Forms.TreeView trvPost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pUnActivePost;
        private System.Windows.Forms.Button btDropFilter;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.TextBox tbNameDocuments;
        private System.Windows.Forms.TextBox tbNamePosts;
        private System.Windows.Forms.TextBox tbNameDeps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pViewDoc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перевестиДокументВАрхивToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьНаСтатусНаОзнакомленииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отозватьСнаОзнакомленииНановыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналСменыСтатусовДокументовToolStripMenuItem;
    }
}

namespace ArchiveDoc
{
    partial class cntDocuments
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
            this.chbUnActivePost = new System.Windows.Forms.CheckBox();
            this.trvDeps = new System.Windows.Forms.TreeView();
            this.trvPost = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDropFilter = new System.Windows.Forms.Button();
            this.btFilter = new System.Windows.Forms.Button();
            this.tbNameDocuments = new System.Windows.Forms.TextBox();
            this.tbNamePosts = new System.Windows.Forms.TextBox();
            this.tbNameDeps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pUnActivePost = new System.Windows.Forms.Panel();
            this.chbUnActiveDocType = new System.Windows.Forms.CheckBox();
            this.pUnActiveTypeDoc = new System.Windows.Forms.Panel();
            this.pNewDoc = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pViewDoc = new System.Windows.Forms.Panel();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.btEditDoc = new System.Windows.Forms.Button();
            this.btDelDoc = new System.Windows.Forms.Button();
            this.btToArchiv = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btViewHisroty = new System.Windows.Forms.Button();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.btDictonaryTypeDoc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbUnActivePost
            // 
            this.chbUnActivePost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUnActivePost.AutoSize = true;
            this.chbUnActivePost.Location = new System.Drawing.Point(45, 627);
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
            this.pUnActivePost.Location = new System.Drawing.Point(20, 626);
            this.pUnActivePost.Name = "pUnActivePost";
            this.pUnActivePost.Size = new System.Drawing.Size(19, 19);
            this.pUnActivePost.TabIndex = 6;
            // 
            // chbUnActiveDocType
            // 
            this.chbUnActiveDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUnActiveDocType.AutoSize = true;
            this.chbUnActiveDocType.Location = new System.Drawing.Point(436, 612);
            this.chbUnActiveDocType.Name = "chbUnActiveDocType";
            this.chbUnActiveDocType.Size = new System.Drawing.Size(184, 17);
            this.chbUnActiveDocType.TabIndex = 0;
            this.chbUnActiveDocType.Text = "недействующий тип документа";
            this.chbUnActiveDocType.UseVisualStyleBackColor = true;
            this.chbUnActiveDocType.CheckedChanged += new System.EventHandler(this.chbUnActiveDocType_CheckedChanged);
            // 
            // pUnActiveTypeDoc
            // 
            this.pUnActiveTypeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pUnActiveTypeDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.pUnActiveTypeDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pUnActiveTypeDoc.Location = new System.Drawing.Point(411, 611);
            this.pUnActiveTypeDoc.Name = "pUnActiveTypeDoc";
            this.pUnActiveTypeDoc.Size = new System.Drawing.Size(19, 19);
            this.pUnActiveTypeDoc.TabIndex = 6;
            // 
            // pNewDoc
            // 
            this.pNewDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pNewDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.pNewDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pNewDoc.Location = new System.Drawing.Point(411, 636);
            this.pNewDoc.Name = "pNewDoc";
            this.pNewDoc.Size = new System.Drawing.Size(19, 19);
            this.pNewDoc.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 639);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "новый";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(555, 639);
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
            this.pViewDoc.Location = new System.Drawing.Point(530, 636);
            this.pViewDoc.Name = "pViewDoc";
            this.pViewDoc.Size = new System.Drawing.Size(19, 19);
            this.pViewDoc.TabIndex = 6;
            // 
            // btAddDoc
            // 
            this.btAddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddDoc.BackgroundImage = global::ArchiveDoc.Properties.Resources.Add;
            this.btAddDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAddDoc.Location = new System.Drawing.Point(764, 612);
            this.btAddDoc.Name = "btAddDoc";
            this.btAddDoc.Size = new System.Drawing.Size(44, 44);
            this.btAddDoc.TabIndex = 7;
            this.btAddDoc.UseVisualStyleBackColor = true;
            this.btAddDoc.Click += new System.EventHandler(this.btAddDoc_Click);
            // 
            // btEditDoc
            // 
            this.btEditDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEditDoc.BackgroundImage = global::ArchiveDoc.Properties.Resources.Edit;
            this.btEditDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btEditDoc.Location = new System.Drawing.Point(813, 612);
            this.btEditDoc.Name = "btEditDoc";
            this.btEditDoc.Size = new System.Drawing.Size(44, 44);
            this.btEditDoc.TabIndex = 7;
            this.btEditDoc.UseVisualStyleBackColor = true;
            this.btEditDoc.Click += new System.EventHandler(this.btEditDoc_Click);
            // 
            // btDelDoc
            // 
            this.btDelDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelDoc.BackgroundImage = global::ArchiveDoc.Properties.Resources.Trash;
            this.btDelDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btDelDoc.Location = new System.Drawing.Point(862, 612);
            this.btDelDoc.Name = "btDelDoc";
            this.btDelDoc.Size = new System.Drawing.Size(44, 44);
            this.btDelDoc.TabIndex = 7;
            this.btDelDoc.UseVisualStyleBackColor = true;
            this.btDelDoc.Click += new System.EventHandler(this.btDelDoc_Click);
            // 
            // btToArchiv
            // 
            this.btToArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btToArchiv.BackgroundImage = global::ArchiveDoc.Properties.Resources.box;
            this.btToArchiv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btToArchiv.Location = new System.Drawing.Point(911, 612);
            this.btToArchiv.Name = "btToArchiv";
            this.btToArchiv.Size = new System.Drawing.Size(44, 44);
            this.btToArchiv.TabIndex = 7;
            this.btToArchiv.UseVisualStyleBackColor = true;
            this.btToArchiv.Click += new System.EventHandler(this.btToArchiv_Click);
            // 
            // btDown
            // 
            this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDown.BackgroundImage = global::ArchiveDoc.Properties.Resources.undo;
            this.btDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btDown.Location = new System.Drawing.Point(911, 510);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(44, 44);
            this.btDown.TabIndex = 7;
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.BackgroundImage = global::ArchiveDoc.Properties.Resources.redo;
            this.btNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btNext.Location = new System.Drawing.Point(911, 561);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(44, 44);
            this.btNext.TabIndex = 7;
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btViewHisroty
            // 
            this.btViewHisroty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btViewHisroty.BackgroundImage = global::ArchiveDoc.Properties.Resources.news;
            this.btViewHisroty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btViewHisroty.Location = new System.Drawing.Point(911, 189);
            this.btViewHisroty.Name = "btViewHisroty";
            this.btViewHisroty.Size = new System.Drawing.Size(44, 44);
            this.btViewHisroty.TabIndex = 7;
            this.btViewHisroty.UseVisualStyleBackColor = true;
            this.btViewHisroty.Click += new System.EventHandler(this.btViewHisroty_Click);
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
            // btDictonaryTypeDoc
            // 
            this.btDictonaryTypeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDictonaryTypeDoc.BackgroundImage = global::ArchiveDoc.Properties.Resources.folder_Dictonary;
            this.btDictonaryTypeDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btDictonaryTypeDoc.Location = new System.Drawing.Point(879, 31);
            this.btDictonaryTypeDoc.Name = "btDictonaryTypeDoc";
            this.btDictonaryTypeDoc.Size = new System.Drawing.Size(66, 66);
            this.btDictonaryTypeDoc.TabIndex = 7;
            this.btDictonaryTypeDoc.UseVisualStyleBackColor = true;
            this.btDictonaryTypeDoc.Click += new System.EventHandler(this.btDictonaryTypeDoc_Click);
            // 
            // cntDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pViewDoc);
            this.Controls.Add(this.pNewDoc);
            this.Controls.Add(this.pUnActiveTypeDoc);
            this.Controls.Add(this.pUnActivePost);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.btEditDoc);
            this.Controls.Add(this.btDelDoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btToArchiv);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btViewHisroty);
            this.Controls.Add(this.btOpenFile);
            this.Controls.Add(this.btDictonaryTypeDoc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trvPost);
            this.Controls.Add(this.trvDeps);
            this.Controls.Add(this.chbUnActiveDocType);
            this.Controls.Add(this.chbUnActivePost);
            this.Name = "cntDocuments";
            this.Size = new System.Drawing.Size(960, 662);
            this.Load += new System.EventHandler(this.cntDocuments_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btDictonaryTypeDoc;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.Button btViewHisroty;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btToArchiv;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btDelDoc;
        private System.Windows.Forms.Button btEditDoc;
        private System.Windows.Forms.Button btAddDoc;
        private System.Windows.Forms.CheckBox chbUnActiveDocType;
        private System.Windows.Forms.Panel pUnActiveTypeDoc;
        private System.Windows.Forms.Panel pNewDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pViewDoc;
    }
}

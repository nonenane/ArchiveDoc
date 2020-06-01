using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ArchiveDoc
{
    public partial class cntDocuments : UserControl
    {
        ArchiveDocAddDoc.transferDocuments transferDoc = new ArchiveDocAddDoc.transferDocuments();

        public cntDocuments()
        {
            InitializeComponent();

            ImageList myImageList = new ImageList();
            myImageList.ImageSize = new Size(24, 24);
            myImageList.Images.Add(Properties.Resources.team);
            myImageList.Images.Add(Properties.Resources.arrow);
            myImageList.Images.Add(Properties.Resources.office);

            trvDeps.ImageList = myImageList;

            ImageList myImageListDocument = new ImageList();
            myImageListDocument.ImageSize = new Size(24, 24);
            myImageListDocument.Images.Add("document", Properties.Resources.document);
            myImageListDocument.Images.Add("arrow", Properties.Resources.arrow);
            myImageListDocument.Images.Add("archive", Properties.Resources.archive);
            myImageListDocument.Images.Add("check", Properties.Resources.check);
            myImageListDocument.Images.Add("post",Properties.Resources.office);

            myImageListDocument.Images.Add("avi", Properties.Resources.avi);
            myImageListDocument.Images.Add("doc", Properties.Resources.doc);
            myImageListDocument.Images.Add("mp3", Properties.Resources.mp3);
            myImageListDocument.Images.Add("pdf", Properties.Resources.pdf);
            myImageListDocument.Images.Add("png", Properties.Resources.png);

            trvPost.ImageList = myImageListDocument;

            //trvPost.MouseDown += (sender, args) =>
            //        trvPost.SelectedNode = trvPost.GetNodeAt(args.X, args.Y);

            trvPost.NodeMouseClick += (sender, args) => trvPost.SelectedNode = args.Node;
            unEnablePostButton();
        }

        private void cntDocuments_Load(object sender, EventArgs e)
        {
            getData();
        }

        #region "Генерация дерева для отделов"

        DataTable dtPostVsDeps;
        DataTable dtDepsToTree;

        private void getTreeDeps(bool isAll = true)
        {
            trvDeps.Nodes.Clear();
            trvPost.Nodes.Clear();
            //treeView1.ShowLines=false;

            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            dtDepsToTree = task.Result;

            if (dtDepsToTree == null || dtDepsToTree.Rows.Count == 0) return;
            if (!dtDepsToTree.Columns.Contains("isTop"))
            {
                DataColumn col = new DataColumn();
                col.ColumnName = "isTop";
                col.DataType = typeof(bool);
                col.DefaultValue = false;
                dtDepsToTree.Columns.Add(col);
                dtDepsToTree.AcceptChanges();
            }

            task = Config.hCntMain.getPostVsDeps(isAll);
            task.Wait();
            dtPostVsDeps = task.Result;

            newTableDepsForTree(dtDepsToTree, dtPostVsDeps);




            EnumerableRowCollection<DataRow> rowCollect = dtDepsToTree.AsEnumerable().Where(r => r.Field<int>("id_Parent") == 0).OrderByDescending(r => r.Field<bool>("isTop"));
            trvDeps.BeginUpdate();

            foreach (DataRow row in rowCollect)
            {
                //TreeNode node = new TreeNode();
                //node.Text = (string)row["name"];
                //addNotePost((Int16)row["id"], node);
                //addNote((Int16)row["id"], node, dtDepsToTree);
                //treeView1.Nodes.Add(node);

                addNoteDeps((Int16)row["id"], null);
            }

            trvDeps.EndUpdate();
        }

        private void addNote(int id_dep, TreeNode parentNote, DataTable dtIn)
        {
            EnumerableRowCollection<DataRow> rowCollect = dtIn.AsEnumerable().Where(r => r.Field<int>("id_Parent") == id_dep).OrderByDescending(r => r.Field<bool>("isTop"));
            //if (rowCollect.Count() == 0) return null;
            foreach (DataRow row in rowCollect)
            {
                TreeNode node = new TreeNode();
                node.Text = (string)row["name"];
                node.ImageIndex = 0;
                addNotePost((Int16)row["id"], node);
                //node.SelectedImageIndex = 1;
                //if ((bool)row["isTop"]) node.BackColor = Color.Blue;
                addNote((Int16)row["id"], node, dtIn);
                //node.Text = (string)row["nameDeps"];
                //node.Text = (string)row["nameDeps"];
                //parentNote.Nodes.Add(node);
                parentNote.Nodes.Add(node);
            }
            //return node;
        }

        private void addNotePost(int id_deps, TreeNode parentNote)
        {
            EnumerableRowCollection<DataRow> rowCollect = dtPostVsDeps.AsEnumerable().Where(r => r.Field<int>("id_Departments") == id_deps);
            if (rowCollect.Count() == 0) return;

            foreach (DataRow row in rowCollect)
            {
                TreeNode node = new TreeNode();
                node.Text = (string)row["namePost"];
                node.ImageIndex = 2;
                node.SelectedImageIndex = 1;
                node.Tag = new Deps();
                ((Deps)node.Tag).setIsPost(true);
                ((Deps)node.Tag).setIdDeps(id_deps);
                ((Deps)node.Tag).setIdPost((int)row["id_Posts"]);

                if (!(bool)row["isActive"]) node.BackColor = pUnActivePost.BackColor;

                parentNote.Nodes.Add(node);

            }
        }

        private void addNoteDeps(int id_deps, TreeNode parentNote)
        {
            TreeNode node = new TreeNode();

            EnumerableRowCollection<DataRow> rowCollect = dtDepsToTree.AsEnumerable().Where(r => r.Field<Int16>("id") == id_deps);
            if (rowCollect.Count() > 0)
            {
                node.Text = (string)rowCollect.First()["name"];
                node.ImageIndex = 0;
                node.SelectedImageIndex = 1;
                node.Tag = new Deps();
                ((Deps)node.Tag).setIsPost(false);
                ((Deps)node.Tag).setIdDeps(id_deps);
                ((Deps)node.Tag).setIdPost(0);
            }

            addNotePost(id_deps, node);


            rowCollect = dtDepsToTree.AsEnumerable().Where(r => r.Field<int>("id_Parent") == id_deps).OrderByDescending(r => r.Field<bool>("isTop"));
            foreach (DataRow row in rowCollect)
            {
                addNoteDeps((Int16)row["id"], node);
            }


            if (parentNote == null)
            {
                trvDeps.Nodes.Add(node);
            }
            else
            {
                parentNote.Nodes.Add(node);
            }
        }

        private void newTableDepsForTree(DataTable dtDeps, DataTable dtPostvsDeps)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Columns.Add("id_Departments", typeof(int));
            dtTmp.Columns.Add("id_Parent", typeof(int));
            //dtTmp.Columns.Add("id_Posts", typeof(int));
            dtTmp.Columns.Add("nameDeps", typeof(string));
            dtTmp.AcceptChanges();

            var groupDepsVsPost = dtPostvsDeps.AsEnumerable().GroupBy(r => new { id_Departments = r.Field<int>("id_Departments") })
                .Select(s => new
                {
                    s.Key.id_Departments
                });

            //foreach (DataRow row in dtPostvsDeps.Rows)
            foreach (var gDep in groupDepsVsPost)
            {
                EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == gDep.id_Departments);
                if (rowCollect.Count() > 0)
                {
                    //DataRow newRow = dtTmp.NewRow();
                    //newRow["id_Departments"] = rowCollect.First()["id"];
                    //newRow["id_Parent"] = rowCollect.First()["id_Parent"];                    
                    //newRow["id_Posts"] = row["id_Posts"];
                    //newRow["nameDeps"] = rowCollect.First()["name"];
                    //dtTmp.Rows.Add(newRow);
                    rowCollect.First()["isTop"] = true;
                }
            }

            //foreach (DataRow row in dtTmp.Copy().AsEnumerable().Where(r => r.Field<int>("id_Parent") != 0))
            foreach (DataRow row in dtDeps.Copy().AsEnumerable().Where(r => r.Field<int>("id_Parent") != 0 && r.Field<bool>("isTop")))
            {
                int id_Parent = (int)row["id_Parent"];
                //if (dtTmp.AsEnumerable().Where(r => r.Field<int>("id_Departments") == id_Parent).Count() == 0)
                //if (dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == id_Parent).Count() == 0)
                //{
                EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == id_Parent);
                //DataRow newRow = dtTmp.NewRow();
                //newRow["id_Departments"] = rowCollect.First()["id"];
                //newRow["id_Parent"] = rowCollect.First()["id_Parent"];
                //newRow["id_Posts"] = 0;
                //newRow["nameDeps"] = rowCollect.First()["name"];
                //dtTmp.Rows.Add(newRow);    
                rowCollect.First()["isTop"] = true;


                if ((int)rowCollect.First()["id_Parent"] != 0)
                    LinkToParent((int)rowCollect.First()["id_Parent"], dtTmp, dtDeps);
                //}
            }


        }

        private void LinkToParent(int id_Parent, DataTable dtTmp, DataTable dtDeps)
        {
            //if (dtTmp.AsEnumerable().Where(r => r.Field<int>("id_Departments") == id_Parent).Count() == 0)
            //{
            EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == id_Parent);
            //DataRow newRow = dtTmp.NewRow();
            //newRow["id_Departments"] = rowCollect.First()["id"];
            //newRow["id_Parent"] = rowCollect.First()["id_Parent"];
            //newRow["id_Posts"] = 0;
            //newRow["nameDeps"] = rowCollect.First()["name"];
            //dtTmp.Rows.Add(newRow);    
            rowCollect.First()["isTop"] = true;


            if ((int)rowCollect.First()["id_Parent"] != 0)
                LinkToParent((int)rowCollect.First()["id_Parent"], dtTmp, dtDeps);
            //}
        }


        #endregion

        //public TreeNode previousSelectedNode = null;

        private void trvDeps_Validating(object sender, CancelEventArgs e)
        {
            //trvDeps.SelectedNode.BackColor = SystemColors.Highlight;
            //trvDeps.SelectedNode.ForeColor = Color.White;
            //previousSelectedNode = trvDeps.SelectedNode;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (previousSelectedNode != null)
            //{
            //    previousSelectedNode.BackColor = trvDeps.SelectedNode.BackColor;
            //    previousSelectedNode.ForeColor = trvDeps.SelectedNode.ForeColor;
            //}

            //Console.WriteLine($"{e.Node.Text}   Id_Deps:{((Deps)e.Node.Tag).getIdDeps()}  Id_Post:{((Deps)e.Node.Tag).getIdPost()}   IsPost:{((Deps)e.Node.Tag).getIsPost()}");
            //getDocuments(((Deps)e.Node.Tag).getIdDeps(), ((Deps)e.Node.Tag).getIdPost(), ((Deps)e.Node.Tag).getIsPost(), true);
            getDataDocuments();
        }


        DataTable dtDocuments;

        private void getDataDocuments()
        {
            unEnablePostButton();
            TreeNode node = trvDeps.SelectedNode;

            if (node == null) return;

            getDocuments(((Deps)node.Tag).getIdDeps(), ((Deps)node.Tag).getIdPost(), ((Deps)node.Tag).getIsPost(), true);
        }

        private void getDocuments(int id_deps, int id_post, bool isPost,bool isFirst)
        {
            Task<DataTable> task = Config.hCntMain.getDoc_TypeDoc_Post(id_post, id_deps,chbUnActiveDocType.Checked);
            task.Wait();

            if (isPost)
            {
                dtDocuments = task.Result;
                init_docTree();
            }
            else
            {
                

                if (isFirst) { dtDocuments = task.Result; }
                else
                {
                    dtDocuments.Merge(task.Result);
                }

                //EnumerableRowCollection<DataRow> rowCollect = dtDepsToTree.AsEnumerable().Where(r => r.Field<int>("id_Parent") == id_deps);//.OrderByDescending(r => r.Field<bool>("isTop"));
                //foreach (DataRow row in rowCollect)
                //{
                //    getDocuments((Int16)row["id"], id_post, isPost,false);
                //}

                if (isFirst)
                {
                    //Тут рисуем дерево
                    init_docTree();
                }
            }
        }

        private void init_docTree()
        {
            trvPost.Nodes.Clear();
            trvPost.BeginUpdate();

            var groupTypeDoc = dtDocuments.AsEnumerable().GroupBy(r => new { id_TypeDoc = r.Field<int>("id_TypeDoc"), nameTypeDoc = r.Field<string>("nameTypeDoc"), isActive = r.Field<bool>("isActive"), npp = r.Field<int>("npp") })
                .Select(s => new { s.Key.id_TypeDoc, s.Key.nameTypeDoc, s.Key.isActive, s.Key.npp })
                .OrderBy(r => r.npp);

            foreach (var gTypeDoc in groupTypeDoc)
            {
                TreeNode node = new TreeNode();
                node.Text = (string)gTypeDoc.nameTypeDoc;
                node.ImageIndex = trvPost.ImageList.Images.IndexOfKey("document");
                node.SelectedImageIndex = trvPost.ImageList.Images.IndexOfKey("arrow");
                if (!gTypeDoc.isActive) node.BackColor = pUnActiveTypeDoc.BackColor;
                addDoc(gTypeDoc.id_TypeDoc, node);
                trvPost.Nodes.Add(node);
            }
            
            trvPost.EndUpdate();
        }

        private void addDoc(int idTypeDoc,TreeNode parentNode)
        {
            EnumerableRowCollection<DataRow> rowCollect = dtDocuments.AsEnumerable().Where(r => r.Field<int>("id_TypeDoc") == idTypeDoc && new List<int> { 1, 2, 3 }.Contains(r.Field<int>("id_Status")));
            if (rowCollect.Count() > 0)
            {
                TreeNode nodeActive = new TreeNode();
                nodeActive.Text = "Действующие";
                nodeActive.ImageIndex = trvPost.ImageList.Images.IndexOfKey("check");
                nodeActive.SelectedImageIndex = trvPost.ImageList.Images.IndexOfKey("arrow");
                addPostDoc(nodeActive, rowCollect.CopyToDataTable());

                parentNode.Nodes.Add(nodeActive);
            }

            rowCollect = dtDocuments.AsEnumerable().Where(r => r.Field<int>("id_TypeDoc") == idTypeDoc && new List<int> { 4 }.Contains(r.Field<int>("id_Status")));
            if (rowCollect.Count() > 0)
            {
                TreeNode nodeArhive = new TreeNode();
                nodeArhive.Text = "Архив";
                nodeArhive.ImageIndex = trvPost.ImageList.Images.IndexOfKey("archive");
                nodeArhive.SelectedImageIndex = trvPost.ImageList.Images.IndexOfKey("arrow");
                addPostDoc(nodeArhive, rowCollect.CopyToDataTable());
                parentNode.Nodes.Add(nodeArhive);
            }
        }

        private void addPostDoc(TreeNode parentNode,DataTable dataTable)
        {
            var groupPost = dataTable.AsEnumerable().GroupBy(r => new { namePost = r.Field<string>("namePost"), id_Posts = r.Field<int>("id_Posts") })
                    .Select(s => new { s.Key.id_Posts, s.Key.namePost });

            foreach (var gPost in groupPost)
            {
                TreeNode node = new TreeNode();
                node.Text = gPost.namePost;
                node.ImageIndex = trvPost.ImageList.Images.IndexOfKey("post");
                node.SelectedImageIndex = trvPost.ImageList.Images.IndexOfKey("arrow");
                addDoc(gPost.id_Posts, node, dataTable);
                parentNode.Nodes.Add(node);
            }
        }

        private void addDoc(int id_Posts, TreeNode parentNode, DataTable dataTable)
        {
            EnumerableRowCollection<DataRow> rowCollect = dataTable.AsEnumerable().Where(r => r.Field<int>("id_Posts") == id_Posts);
            foreach (DataRow row in rowCollect)
            {
                TreeNode node = new TreeNode();
                node.Text = (string)row["nameDoc"];
                node.Tag = new Document();
                string extension = Path.GetExtension((string)row["FileName"]).Replace(".", "");
                int indexKey = trvPost.ImageList.Images.IndexOfKey(extension);
                if (indexKey == -1)
                    indexKey = trvPost.ImageList.Images.IndexOfKey("doc");
                node.ImageIndex = indexKey;
                node.SelectedImageIndex = trvPost.ImageList.Images.IndexOfKey("arrow");

                ((Document)node.Tag).id_document = (int)row["idDoc"];
                ((Document)node.Tag).id_documentVsPost = (int)row["id_documentVsPost"];
                ((Document)node.Tag).id_Status = (int)row["id_Status"];
                node.ContextMenuStrip = contextMenuStrip1;

                if ((int)row["id_Status"] == 1)
                    node.BackColor = pNewDoc.BackColor;
                else
                     if ((int)row["id_Status"] == 2) node.BackColor = pViewDoc.BackColor;

                parentNode.Nodes.Add(node);
            }
        }

        private void chbUnActivePost_CheckedChanged(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            getTreeDeps(chbUnActivePost.Checked);
        }

        private void btDictonaryTypeDoc_Click(object sender, EventArgs e)
        {
            new ArchiveDocaTypeDoc.frmList().ShowDialog();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (trvPost.SelectedNode == null) return;
            object objSelectTag = trvPost.SelectedNode.Tag;
            if (objSelectTag == null) return;
            if (!(objSelectTag is Document)) return;
            Task<DataTable> task = Config.hCntMain.getDocumentBytes(((Document)objSelectTag).id_document);
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0)
            {
                byte[] file = (byte[])task.Result.Rows[0]["DocFile"];
                string fileName = (string)task.Result.Rows[0]["FileName"];
                if (!Directory.Exists(Application.StartupPath + @"\tmp\"))
                    Directory.CreateDirectory(Application.StartupPath + @"\tmp\");
                File.WriteAllBytes(Application.StartupPath + @"\tmp\" + fileName, file);
                Process.Start(Application.StartupPath + @"\tmp\" + fileName);
            }
        }

        private void btViewHisroty_Click(object sender, EventArgs e)
        {
            if (trvPost.SelectedNode == null) return;
            object objSelectTag = trvPost.SelectedNode.Tag;
            if (objSelectTag == null) return;
            if (!(objSelectTag is Document)) return;

            new ArchiveDocJournalStatusHistory.frmHistory() { id_DocumentsDepartmentsPosts = ((Document)objSelectTag).id_documentVsPost }.ShowDialog();
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new ArchiveDocAddDoc.frmAddDoc() { Text = "Добавление документа" }.ShowDialog())
                getDataDocuments();
        }

        private void btEditDoc_Click(object sender, EventArgs e)
        {
            if (trvPost.SelectedNode == null) return;
            object objSelectTag = trvPost.SelectedNode.Tag;
            if (objSelectTag == null) return;
            if (!(objSelectTag is Document)) return;

            if (!transferDoc.getStatusDocuments(((Document)objSelectTag).id_document, 1)) return;

            new ArchiveDocAddDoc.frmAddDoc() { Text = "Редактирование документа", id = ((Document)objSelectTag).id_document }.ShowDialog();
        }

        private void btDelDoc_Click(object sender, EventArgs e)
        {
            if (trvPost.SelectedNode == null) return;
            object objSelectTag = trvPost.SelectedNode.Tag;
            if (objSelectTag == null) return;
            if (!(objSelectTag is Document)) return;

            //if (!transferDoc.getStatusDocuments(((Document)objSelectTag).id_document, 1)) return;
            if (!transferDoc.deleteDocuments(((Document)objSelectTag).id_document)) return;            
        }

        private void chbUnActiveDocType_CheckedChanged(object sender, EventArgs e)
        {
            getDataDocuments();
        }

        private void btToArchiv_Click(object sender, EventArgs e)
        {
            if (trvPost.SelectedNode == null) return;
            object objSelectTag = trvPost.SelectedNode.Tag;
            if (objSelectTag == null) return;
            if (!(objSelectTag is Document)) return;

            if (!transferDoc.getStatusDocuments(((Document)objSelectTag).id_document, 3)) return;
            //if (!transferDoc.setStatusDocument(((Document)objSelectTag).id_document, 4)) return;

            DialogResult dlgResult = new MyMessageBox.MyMessageBox("Вы хотите заменить помещаемый\n\"В архив\" документ на новый?", "Перевод документа в архив",
                MyMessageBox.MessageBoxButtons.YesNoCancel,
                new List<string> { "Да, заменить на новый", "Нет, не заменять", "Отмена" }).ShowDialog();
            if (dlgResult == DialogResult.Cancel) return;

            if (DialogResult.OK == new ArchiveDocAddDoc.justification.frmAdd() { id_Document = ((Document)objSelectTag).id_document }.ShowDialog())
            { }

            if (DialogResult.Yes == dlgResult) {
                if (DialogResult.OK == new ArchiveDocAddDoc.frmAddDoc() { Text = "Добавление документа",id_new = ((Document)objSelectTag).id_document }.ShowDialog())
                    getDataDocuments();
            }

            getDataDocuments();
        }

        private void btNext_Click(object sender, EventArgs e)
        {            
            if (trvPost.SelectedNode == null) return;
            object objSelectTag = trvPost.SelectedNode.Tag;
            if (objSelectTag == null) return;
            if (!(objSelectTag is Document)) return;

            if (!transferDoc.getStatusDocuments(((Document)objSelectTag).id_document, 1)) return;
            DialogResult dlgResult = new MyMessageBox.MyMessageBox("Вы хотите передать документ\n\"На ознакомление\"?", "Передать документ на ознакомление",
                MyMessageBox.MessageBoxButtons.YesNo,
                new List<string> { "Да", "Нет", "Отмена" }).ShowDialog();
            if (dlgResult == DialogResult.No) return;

            if (!transferDoc.setStatusDocument(((Document)objSelectTag).id_document, 2)) return;


            getDataDocuments();
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            if (trvPost.SelectedNode == null) return;
            object objSelectTag = trvPost.SelectedNode.Tag;
            if (objSelectTag == null) return;
            if (!(objSelectTag is Document)) return;

            if (!transferDoc.getStatusDocuments(((Document)objSelectTag).id_document, 2)) return;

            DialogResult dlgResult = new MyMessageBox.MyMessageBox("Вы хотите отозвать документ\n\"На ознакомление\" и сделать статус \"Новый\"?", "Отозвать документ", MyMessageBox.MessageBoxButtons.YesNo, new List<string> { "Да, отозвать", "Нет, не отзывать", "Отмена" }).ShowDialog();
            if (dlgResult == DialogResult.No) return;

            if (DialogResult.OK == new ArchiveDocAddDoc.redoDocument.frmAdd() { id_Document = ((Document)objSelectTag).id_document }.ShowDialog())
            {
                getDataDocuments();
            }

            //if (!transferDoc.setStatusDocument(((Document)objSelectTag).id_document, 1)) return;

            
        }

        private void btFilter_Click(object sender, EventArgs e)
        {

        }

        private void btDropFilter_Click(object sender, EventArgs e)
        {
            tbNameDeps.Clear();
            tbNameDocuments.Clear();
            tbNamePosts.Clear();
        }

        private void btDictonaryPost_Click(object sender, EventArgs e)
        {
            new ArchiveDocPost.frmList().ShowDialog();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btOpenFile_Click(null, null);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btAddDoc_Click(null, null);
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btEditDoc_Click(null, null);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btDelDoc_Click(null, null);
        }

        private void перевестиДокументВАрхивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btToArchiv_Click(null, null);
        }

        private void сменитьНаСтатусНаОзнакомленииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btNext_Click(null, null);
        }

        private void отозватьСнаОзнакомленииНановыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btDown_Click(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            TreeNode node = trvPost.SelectedNode;
            if (node == null) { e.Cancel = true;return; }         
            object objSelectTag = trvPost.SelectedNode.Tag;
            if (objSelectTag == null) { e.Cancel = true; return; }
            if (!(objSelectTag is Document)) { e.Cancel = true; return; }

            редактироватьToolStripMenuItem.Enabled = ((Document)objSelectTag).id_Status == 1;
            удалитьToolStripMenuItem.Enabled = ((Document)objSelectTag).id_Status == 1;

            перевестиДокументВАрхивToolStripMenuItem.Enabled = ((Document)objSelectTag).id_Status == 3;
            сменитьНаСтатусНаОзнакомленииToolStripMenuItem.Enabled = ((Document)objSelectTag).id_Status == 1;
            отозватьСнаОзнакомленииНановыйToolStripMenuItem.Enabled = ((Document)objSelectTag).id_Status == 2;           
        }

        private void журналСменыСтатусовДокументовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btViewHisroty_Click(null, null);
        }

        private void trvPost_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = trvPost.SelectedNode;

            if (node == null || !(node.Tag is Document))
            {
                unEnablePostButton();
                return;
            }

            object objSelectTag = trvPost.SelectedNode.Tag;

            btEditDoc.Enabled = ((Document)objSelectTag).id_Status == 1;
            btDelDoc.Enabled = ((Document)objSelectTag).id_Status == 1;
            btDown.Enabled = ((Document)objSelectTag).id_Status == 2;
            btNext.Enabled = ((Document)objSelectTag).id_Status == 1;
            btToArchiv.Enabled = ((Document)objSelectTag).id_Status == 3;
            btOpenFile.Enabled = true;
            btViewHisroty.Enabled = true;
        }

        private void unEnablePostButton()        
        {
            btEditDoc.Enabled = false;
            btDelDoc.Enabled = false;
            btDown.Enabled = false;
            btNext.Enabled = false;
            btToArchiv.Enabled = false;
            btOpenFile.Enabled = false;
            btViewHisroty.Enabled = false;
        }
    }   
}

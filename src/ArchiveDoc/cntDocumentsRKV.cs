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
using Nwuram.Framework.Settings.User;

namespace ArchiveDoc
{
    public partial class cntDocumentsRKV : UserControl
    {
        ArchiveDocAddDoc.transferDocuments transferDoc = new ArchiveDocAddDoc.transferDocuments();
        ArchiveDocSettings.LinkToProcedures linkToProcSettings = new ArchiveDocSettings.LinkToProcedures();
        public cntDocumentsRKV()
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

            //trvPost.NodeMouseClick += (sender, args) => trvPost.SelectedNode = args.Node;
            unEnablePostButton();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btNext, "Подтвердить");
            tp.SetToolTip(btOpenFile, "Открыть");
            tp.SetToolTip(btFilter, "Фильтрация");
            tp.SetToolTip(btDropFilter, "Сбросить фильтр");
            
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

            DataTable dtDepsLinkToDep =  linkToProcSettings.getDepartmentsAccessView(UserSettings.User.IdDepartment);


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

                col = new DataColumn();
                col.ColumnName = "isUsed";
                col.DataType = typeof(bool);
                col.DefaultValue = false;
                dtDepsToTree.Columns.Add(col);

                dtDepsToTree.AcceptChanges();
            }

            task = Config.hCntMain.getPostVsDeps(isAll);
            task.Wait();
            dtPostVsDeps = task.Result;

            newTableDepsForTree(dtDepsToTree, dtPostVsDeps, dtDepsLinkToDep);

            EnumerableRowCollection<DataRow> rowCollect = dtDepsToTree.AsEnumerable().Where(r => r.Field<int>("id_Parent") == 0 && r.Field<bool>("isUsed")).OrderByDescending(r => r.Field<bool>("isTop"));
            trvDeps.BeginUpdate();

            foreach (DataRow row in rowCollect)
            {
                addNoteDeps((Int16)row["id"], null);
            }

            trvDeps.EndUpdate();
        }

        //private void addNote(int id_dep, TreeNode parentNote, DataTable dtIn)
        //{
        //    EnumerableRowCollection<DataRow> rowCollect = dtIn.AsEnumerable().Where(r => r.Field<int>("id_Parent") == id_dep).OrderByDescending(r => r.Field<bool>("isTop"));
        //    //if (rowCollect.Count() == 0) return null;
        //    foreach (DataRow row in rowCollect)
        //    {
        //        TreeNode node = new TreeNode();
        //        node.Text = (string)row["name"];
        //        node.ImageIndex = 0;
        //        addNotePost((Int16)row["id"], node);
        //        //node.SelectedImageIndex = 1;
        //        //if ((bool)row["isTop"]) node.BackColor = Color.Blue;
        //        addNote((Int16)row["id"], node, dtIn);
        //        //node.Text = (string)row["nameDeps"];
        //        //node.Text = (string)row["nameDeps"];
        //        //parentNote.Nodes.Add(node);
        //        parentNote.Nodes.Add(node);
        //    }
        //    //return node;
        //}

        private void addNotePost(int id_deps, TreeNode parentNote)
        {
            EnumerableRowCollection<DataRow> rowCollect = dtPostVsDeps.AsEnumerable().Where(r => r.Field<int>("id_Departments") == id_deps && r.Field<string>("namePost").ToLower().Contains(tbNamePosts.Text.ToLower()));
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

            EnumerableRowCollection<DataRow> rowCollect = dtDepsToTree.AsEnumerable().Where(r => r.Field<Int16>("id") == id_deps && r.Field<bool>("isUsed"));
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


            rowCollect = dtDepsToTree.AsEnumerable().Where(r => r.Field<int>("id_Parent") == id_deps && r.Field<bool>("isUsed")).OrderByDescending(r => r.Field<bool>("isTop"));
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

        private void newTableDepsForTree(DataTable dtDeps, DataTable dtPostvsDeps, DataTable dtDepsLinkToDep)
        {
            DataTable dtTmp = new DataTable();

            var groupDepsVsPost = dtPostvsDeps.AsEnumerable().GroupBy(r => new { id_Departments = r.Field<int>("id_Departments") })
                .Select(s => new
                {
                    s.Key.id_Departments
                });

            foreach (var gDep in groupDepsVsPost)
            {
                EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == gDep.id_Departments);
                if (rowCollect.Count() > 0)
                {
                    rowCollect.First()["isTop"] = true;
                }
            }




            if (tbNameDeps.Text.Trim().Length != 0 || tbNamePosts.Text.Trim().Length != 0 || tbNameDocuments.Text.Trim().Length != 0)
            {
                filterTable(dtDeps, dtPostvsDeps, dtDepsLinkToDep);               
            }
            else
            {
                foreach (DataRow row in dtDepsLinkToDep.Rows)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == (int)row["id_DepartmentsView"]);
                    if (rowCollect.Count() > 0)
                    {
                        rowCollect.First()["isUsed"] = true;
                    }
                }
            }


            foreach (DataRow row in dtDeps.Copy().AsEnumerable().Where(r => r.Field<int>("id_Parent") != 0 
            //&& r.Field<bool>("isTop") 
            && r.Field<bool>("isUsed")))
            {
                int id_Parent = (int)row["id_Parent"];
                EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == id_Parent);
                rowCollect.First()["isTop"] = true;
                rowCollect.First()["isUsed"] = true;

                if ((int)rowCollect.First()["id_Parent"] != 0)
                    LinkToParent((int)rowCollect.First()["id_Parent"], dtTmp, dtDeps);
            }


        }

        private void filterTable(DataTable dtDeps, DataTable dtPostvsDeps, DataTable dtDepsLinkToDep)
        {
            if (tbNameDocuments.Text.Trim().Length > 0)
            {
                Task<DataTable> task = Config.hCntMain.getDoc_TypeDoc_Post(0, 0, false);
                task.Wait();

                if (tbNameDocuments.Text.Trim().Length > 0 && task.Result == null) return;

                foreach (DataRow row in dtDepsLinkToDep.Rows)
                {
                    var rowCollectDocument = task.Result.AsEnumerable()
                    .Where(r =>
                            r.Field<int>("id_Departments") == (int)row["id_DepartmentsView"]
                            && r.Field<string>("namePost").ToLower().Contains(tbNamePosts.Text.ToLower())
                            && r.Field<string>("nameDoc").ToLower().Contains(tbNameDocuments.Text.ToLower())
                            && ((new List<int> { 4 }.Contains(r.Field<int>("id_Status")) && r.Field<bool>("ViewArchive")) || new List<int> { 2, 3 }.Contains(r.Field<int>("id_Status")))
                            )
                    .GroupBy(r => new { id_Departments = r.Field<int>("id_Departments") })
                    .Select(s => new { s.Key.id_Departments });

                    foreach (var gRDoc in rowCollectDocument)
                    {
                        var groupDepsVsPost_1 = dtPostvsDeps.AsEnumerable()
                                     .Where(r =>
                                        r.Field<int>("id_Departments") == gRDoc.id_Departments
                                        && r.Field<string>("namePost").ToLower().Contains(tbNamePosts.Text.ToLower())
                                        && r.Field<string>("nameDeps").ToLower().Contains(tbNameDeps.Text.ToLower())
                                        )
                                     .GroupBy(r => new { id_Departments = r.Field<int>("id_Departments") })
                                     .Select(s => new
                                     {
                                         s.Key.id_Departments
                                     });

                        foreach (var gDepsv1 in groupDepsVsPost_1)
                        {
                            EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == gDepsv1.id_Departments);
                            if (rowCollect.Count() > 0)
                            {
                                rowCollect.First()["isUsed"] = true;
                            }
                        }
                    }
                }
            }
            else if (tbNamePosts.Text.Trim().Length > 0)
            {
                foreach (DataRow row in dtDepsLinkToDep.Rows)
                {
                    var groupDepsVsPost_1 = dtPostvsDeps.AsEnumerable()
                    .Where(r =>
                        r.Field<int>("id_Departments") == (int)row["id_DepartmentsView"]
                        && r.Field<string>("namePost").ToLower().Contains(tbNamePosts.Text.ToLower()) 
                        && r.Field<string>("nameDeps").ToLower().Contains(tbNameDeps.Text.ToLower())
                        )
                    .GroupBy(r => new { id_Departments = r.Field<int>("id_Departments") })
                    .Select(s => new
                    {
                          s.Key.id_Departments
                    });

                    foreach (var gDepsv1 in groupDepsVsPost_1)
                    {
                        EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == gDepsv1.id_Departments);
                        if (rowCollect.Count() > 0)
                        {
                            rowCollect.First()["isUsed"] = true;
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in dtDepsLinkToDep.Rows)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == (int)row["id_DepartmentsView"] && r.Field<string>("name").ToLower().Contains(tbNameDeps.Text.ToLower()));
                    if (rowCollect.Count() > 0)
                    {
                        rowCollect.First()["isUsed"] = true;
                    }
                }
            }
        }

        private void LinkToParent(int id_Parent, DataTable dtTmp, DataTable dtDeps)
        {
            EnumerableRowCollection<DataRow> rowCollect = dtDeps.AsEnumerable().Where(r => r.Field<Int16>("id") == id_Parent);
            rowCollect.First()["isTop"] = true;
            rowCollect.First()["isUsed"] = true;

            if ((int)rowCollect.First()["id_Parent"] != 0)
                LinkToParent((int)rowCollect.First()["id_Parent"], dtTmp, dtDeps);
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
            Task<DataTable> task = Config.hCntMain.getDoc_TypeDoc_Post(id_post, id_deps,false);
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

            var groupTypeDoc = dtDocuments.AsEnumerable()
                .Where(r=> r.Field<string>("namePost").ToLower().Contains(tbNamePosts.Text.ToLower()) && r.Field<string>("nameDoc").ToLower().Contains(tbNameDocuments.Text.ToLower()))
                .GroupBy(r => new { id_TypeDoc = r.Field<int>("id_TypeDoc"), nameTypeDoc = r.Field<string>("nameTypeDoc"), isActive = r.Field<bool>("isActive"), npp = r.Field<int>("npp"), ViewArchive = r.Field<bool>("ViewArchive") })
                .Select(s => new { s.Key.id_TypeDoc, s.Key.nameTypeDoc, s.Key.isActive, s.Key.npp,s.Key.ViewArchive })
                .OrderBy(r => r.npp);

            foreach (var gTypeDoc in groupTypeDoc)
            {
                TreeNode node = new TreeNode();
                node.Text = (string)gTypeDoc.nameTypeDoc;
                node.ImageIndex = trvPost.ImageList.Images.IndexOfKey("document");
                node.SelectedImageIndex = trvPost.ImageList.Images.IndexOfKey("arrow");
                addHeaderDoc(gTypeDoc.id_TypeDoc, node,gTypeDoc.ViewArchive);
                trvPost.Nodes.Add(node);
            }
            
            trvPost.EndUpdate();
        }

        private void addHeaderDoc(int idTypeDoc,TreeNode parentNode,bool ViewArchive)
        {
            EnumerableRowCollection<DataRow> rowCollect = dtDocuments.AsEnumerable()
                .Where(r => r.Field<int>("id_TypeDoc") == idTypeDoc
                && r.Field<string>("namePost").ToLower().Contains(tbNamePosts.Text.ToLower())
                && r.Field<string>("nameDoc").ToLower().Contains(tbNameDocuments.Text.ToLower())
                && new List<int> { 2, 3 }.Contains(r.Field<int>("id_Status")));
            if (rowCollect.Count() > 0)
            {
                TreeNode nodeActive = new TreeNode();
                nodeActive.Text = "Действующие";
                nodeActive.ImageIndex = trvPost.ImageList.Images.IndexOfKey("check");
                nodeActive.SelectedImageIndex = trvPost.ImageList.Images.IndexOfKey("arrow");
                addPostDoc(nodeActive, rowCollect.CopyToDataTable());

                parentNode.Nodes.Add(nodeActive);
            }

            if (ViewArchive)
            {
                rowCollect = dtDocuments.AsEnumerable()
                    .Where(r => r.Field<int>("id_TypeDoc") == idTypeDoc
                    && r.Field<string>("namePost").ToLower().Contains(tbNamePosts.Text.ToLower())
                    && r.Field<string>("nameDoc").ToLower().Contains(tbNameDocuments.Text.ToLower())
                    && new List<int> { 4 }.Contains(r.Field<int>("id_Status")));
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
        }

        private void addPostDoc(TreeNode parentNode,DataTable dataTable)
        {
            var groupPost = dataTable.AsEnumerable()
                .Where(r=> r.Field<string>("namePost").ToLower().Contains(tbNamePosts.Text.ToLower()) && r.Field<string>("nameDoc").ToLower().Contains(tbNameDocuments.Text.ToLower()))
                .GroupBy(r => new { namePost = r.Field<string>("namePost"), id_Posts = r.Field<int>("id_Posts") })
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
            EnumerableRowCollection<DataRow> rowCollect = dataTable.AsEnumerable()
                .Where(r => r.Field<int>("id_Posts") == id_Posts && r.Field<string>("nameDoc").ToLower().Contains(tbNameDocuments.Text.ToLower()));
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
                ((Document)node.Tag).isBrowse = (bool)row["isBrowse"];
                ((Document)node.Tag).isWorkDep = (int)row["id_Departments"] == UserSettings.User.IdDepartment;
                
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

                if (!File.Exists(Application.StartupPath + @"\tmp\" + fileName))
                {
                    File.WriteAllBytes(Application.StartupPath + @"\tmp\" + fileName, file);                    
                }
                Process.Start(Application.StartupPath + @"\tmp\" + fileName);

                if (((Document)objSelectTag).isWorkDep)
                {
                    if (!transferDoc.setBrowseDocument(((Document)objSelectTag).id_documentVsPost)) return;

                    ((Document)objSelectTag).isBrowse = true;
                    btNext.Enabled = ((Document)objSelectTag).id_Status == 2 && ((Document)objSelectTag).isBrowse && ((Document)objSelectTag).isWorkDep;

                }
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

            //if (!transferDoc.getStatusDocuments(((Document)objSelectTag).id_document, 1)) return;
            DialogResult dlgResult = new MyMessageBox.MyMessageBox("Вы хотите установить статус  документа на \n\"Ознакомлен\"?", "Ознакомление с документов",
                MyMessageBox.MessageBoxButtons.YesNo,
                new List<string> { "Да", "Нет", "Отмена" }).ShowDialog();
            if (dlgResult == DialogResult.No) return;

            if (!transferDoc.setStatusSingleDocument(((Document)objSelectTag).id_document, ((Document)objSelectTag).id_documentVsPost, 3)) return;


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
            getData();
        }

        private void btDropFilter_Click(object sender, EventArgs e)
        {
            tbNameDeps.Clear();
            tbNameDocuments.Clear();
            tbNamePosts.Clear();
            getData();
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

            btNext.Enabled = ((Document)objSelectTag).id_Status == 2 && ((Document)objSelectTag).isBrowse && ((Document)objSelectTag).isWorkDep;
            btOpenFile.Enabled = true;
        }

        private void unEnablePostButton()
        {
            btNext.Enabled = false;
            btOpenFile.Enabled = false;
        }
    }   
}

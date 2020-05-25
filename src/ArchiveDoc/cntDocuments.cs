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

namespace ArchiveDoc
{
    public partial class cntDocuments : UserControl
    {
        public cntDocuments()
        {
            InitializeComponent();

            ImageList myImageList = new ImageList();
            myImageList.ImageSize = new Size(20, 20);
            myImageList.Images.Add(Properties.Resources.people);
            myImageList.Images.Add(Properties.Resources.arrow);
            myImageList.Images.Add(Properties.Resources.office);

            trvDeps.ImageList = myImageList;

            //treeView1.ImageIndex = -1;
            //treeView1.ImageIndex = 0;
            trvDeps.SelectedImageIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getTreeDeps(checkBox1.Checked);
        }

        #region "Генерация дерева для отделов"

        DataTable dtPostVsDeps;
        DataTable dtDepsToTree;

        private void getTreeDeps(bool isAll = true)
        {
            trvDeps.Nodes.Clear();
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Console.WriteLine($"{e.Node.Text}   Id_Deps:{((Deps)e.Node.Tag).getIdDeps()}  Id_Post:{((Deps)e.Node.Tag).getIdPost()}   IsPost:{((Deps)e.Node.Tag).getIsPost()}");

            getDocuments(((Deps)e.Node.Tag).getIdDeps(), ((Deps)e.Node.Tag).getIdPost(), ((Deps)e.Node.Tag).getIsPost(),true);
        }

        DataTable dtDocuments;

        private void getDocuments(int id_deps, int id_post, bool isPost,bool isFirst)
        {
            Task<DataTable> task = Config.hCntMain.getDoc_TypeDoc_Post(id_post, id_deps);
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

                EnumerableRowCollection<DataRow> rowCollect = dtDepsToTree.AsEnumerable().Where(r => r.Field<int>("id_Parent") == id_deps);//.OrderByDescending(r => r.Field<bool>("isTop"));
                foreach (DataRow row in rowCollect)
                {
                    getDocuments((Int16)row["id"], id_post, isPost,false);
                }

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

            var groupTypeDoc = dtDocuments.AsEnumerable().GroupBy(r => new { id_TypeDoc = r.Field<int>("id_TypeDoc"), nameTypeDoc = r.Field<string>("nameTypeDoc") })
                .Select(s => new { s.Key.id_TypeDoc, s.Key.nameTypeDoc });

            foreach (var gTypeDoc in groupTypeDoc)
            {
                TreeNode node = new TreeNode();
                node.Text = (string)gTypeDoc.nameTypeDoc;
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
                nodeActive.Text = "Активные";


                parentNode.Nodes.Add(nodeActive);
            }

            rowCollect = dtDocuments.AsEnumerable().Where(r => r.Field<int>("id_TypeDoc") == idTypeDoc && new List<int> { 4 }.Contains(r.Field<int>("id_Status")));
            if (rowCollect.Count() > 0)
            {
                TreeNode nodeArhive = new TreeNode();
                nodeArhive.Text = "Архив";
                parentNode.Nodes.Add(nodeArhive);
            }
        }
    }


    public class Deps
    {
        //private List<int> listDeps = new List<int>();
        private int id_deps;
        private bool isPost;
        private int id_Post;

        public void setIdDeps(int id_deps){this.id_deps = id_deps;}

        public int getIdDeps(){return this.id_deps;}

        public void setIsPost(bool isPost){ this.isPost = isPost; }

        public bool getIsPost() { return this.isPost; }

        public void setIdPost(int id_Post) { this.id_Post = id_Post; }

        public int getIdPost() { return this.id_Post; }
    }
}

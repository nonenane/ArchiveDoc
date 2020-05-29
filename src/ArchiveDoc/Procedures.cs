using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;

namespace ArchiveDoc
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
              : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();
       
        /// <summary>
        /// Получение справочника отделов
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getDeps(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[ArchiveDoc].[getDepartmentsAdm]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                if (dtResult.Columns.Contains("isOffice")) dtResult.Columns.Remove("isOffice");
                if (dtResult.Columns.Contains("isUniversam")) dtResult.Columns.Remove("isUniversam");
            }

            if (withAllDeps)
            {
                if (dtResult != null)
                {
                    if (!dtResult.Columns.Contains("isMain"))
                    {
                        DataColumn col = new DataColumn("isMain", typeof(int));
                        col.DefaultValue = 1;
                        dtResult.Columns.Add(col);
                        dtResult.AcceptChanges();
                    }

                    DataRow row = dtResult.NewRow();

                    row["name"] = "Все отделы";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.Sort = "isMain asc, name asc";
                    dtResult = dtResult.DefaultView.ToTable().Copy();
                }
            }

            return dtResult;
        }
      
        /// <summary>
        /// Получение списка должностей по отделам
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getPostVsDeps(bool isAll)
        {
            ap.Clear();
            ap.Add(isAll);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getPostVsDeps]",
                 new string[1] { "@isAll"},
                 new DbType[1] { DbType.Boolean }, ap);

            return dtResult;
        }

        /// <summary>
        /// Получение списка должностей по отделам
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getDoc_TypeDoc_Post(int id_Posts,int id_Departments,bool isAll)
        {
            ap.Clear();
            ap.Add(id_Posts);
            ap.Add(id_Departments);
            ap.Add(isAll);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getDoc_TypeDoc_Post]",
                 new string[3] { "@id_Posts", "@id_Departments","@isAll" },
                 new DbType[3] { DbType.Int32,DbType.Int32,DbType.Boolean }, ap);

            return dtResult;
        }

        /// <summary>Получение списка документов для добавления в документ
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getDocumentBytes(int id)
        {
            ap.Clear();
            ap.Add(id);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getDocumentBytes]",
                 new string[1] { "@id" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }
    }
}

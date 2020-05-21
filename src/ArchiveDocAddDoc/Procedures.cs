using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;

namespace ArchiveDocAddDoc
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
              : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();

        /// <summary>
        /// Получение справочника типов документов
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getTypeDoc()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getTypeDoc]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

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
        /// Получение справочника должностей
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getPost(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getPost]",
                 new string[0] { },
                 new DbType[0] { }, ap);
        
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

                    row["cName"] = "Все должности";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    row["isActive"] = true;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.Sort = "isMain asc, cName asc";
                    dtResult.DefaultView.RowFilter = "isActive = 1";
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
        public async Task<DataTable> getPostVsDeps()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getPostVsDeps]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        /// <summary>
        /// Получение списка документов для добавления в документ
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getDocumentsForAdd()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getDocumentsForAdd]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }


        #region "Добавление документа"

        /// <summary>
        /// Запись документа в базу
        /// </summary>
        /// <param name="id">Код записи</param>
        /// <param name="cName">Наименование </param>
        /// <param name="npp">Аббревиатура</param>
        /// <param name="ViewArchive"></param>
        /// <param name="ViewAdd"></param>
        /// <param name="isActive">признак активности записи</param>  
        /// <param name="isDel">Признак удаления записи</param>
        /// <param name="result">Результирующая для проверки</param>
        /// <returns>Таблица с данными</returns>
        /// <param name="id">код созданной записи</param>

        public async Task<DataTable> setDocuments(int id, string cName, string fileName, byte[] docBytes, int id_DocType, bool isDel, int result)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(fileName);
            ap.Add(docBytes);
            ap.Add(id_DocType);            
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(result);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_setDocuments]",
                 new string[8] { "@id", "@cName", "@fileName", "@docBytes", "@id_DocType", "@id_user", "@result", "@isDel" },
                 new DbType[8] { DbType.Int32, DbType.String, DbType.String, DbType.Binary, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);

            return dtResult;
        }

        #endregion
        
    }
}

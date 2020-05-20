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

        #region "Справочник типов документов"

        /// <summary>
        /// Получение справочника типов документов
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getTypeDoc()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[ArchiveDoc].[getTypeDoc]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }


        /// <summary>
        /// Запись справочника типов отзывов
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

        public async Task<DataTable> setTypeDoc(int id, string cName, int npp,bool ViewAdd, bool ViewArchive, bool isActive, bool isDel, int result)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(npp);
            ap.Add(ViewAdd);
            ap.Add(ViewArchive);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(result);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[setTypeDoc]",
                 new string[9] { "@id", "@cName", "@npp", "@ViewAdd", "@ViewArchive", "@isActive", "@id_user", "@result", "@isDel" },
                 new DbType[9] { DbType.Int32, DbType.String, DbType.Int32, DbType.Boolean, DbType.Boolean, DbType.Boolean, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);

            return dtResult;
        }

        #endregion

        #region "Ввод обоснования перевода в архив"

        /// <summary>
        /// Запись справочника типов отзывов
        /// </summary>
        /// <param name="id_TypeDoc">Код записи</param>
        /// <param name="ArchiveComment">Наименование </param>
        /// <param name="BaseDocumentsArchive">Аббревиатура</param>        
        /// <returns>Таблица с данными</returns>
        

        public async Task<DataTable> setJustification(int id_TypeDoc, string ArchiveComment, string BaseDocumentsArchive)
        {
            ap.Clear();
            ap.Add(id_TypeDoc);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(ArchiveComment);
            ap.Add(BaseDocumentsArchive);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[setJustification]",
                 new string[4] { "@id_TypeDoc", "@id_user", "@ArchiveComment", "@BaseDocumentsArchive" },
                 new DbType[4] { DbType.Int32, DbType.Int32, DbType.String, DbType.String }, ap);

            return dtResult;
        }



        #endregion
    }
}

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

        #region "Справочник типов документов"

        /// <summary>
        /// Запись справочника типов отзывов
        /// </summary>
        /// <param name="id">Код записи</param>
        /// <param name="cName">Наименование </param>
        /// <param name="Abbreviation">Аббревиатура</param>
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
        
    }
}

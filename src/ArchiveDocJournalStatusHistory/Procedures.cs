using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;

namespace ArchiveDocJournalStatusHistory
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
        public async Task<DataTable> getHistoryStatus(int id)
        {
            ap.Clear();
            ap.Add(id);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getHistoryStatus]",
                 new string[1] { "@id_DocumentsDepartmentsPosts"},
                 new DbType[1] {DbType.Int32 }, ap);

            return dtResult;
        }
        
        #endregion

      
    }
}

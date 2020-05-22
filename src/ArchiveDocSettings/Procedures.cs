﻿using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;

namespace ArchiveDocSettings
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

        #region "Settings"
        /// <summary>
        /// Получение справочника типов документов
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getGroupFile(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getGroupFile]",
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

                    row["cName"] = "Все типы";
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
        /// Получение справочника типов документов
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getTypeFile()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getTypeFile]",
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

        public async Task<DataTable> setTypeFile(int id, int id_GroupFile, string Extension, bool isUse, bool isActive, bool isDel, int result)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_GroupFile);
            ap.Add(Extension);
            ap.Add(isUse);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(result);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_setTypeFile]",
                 new string[8] { "@id", "@id_GroupFile", "@Extension", "@isUse", "@isActive", "@id_user", "@result", "@isDel" },
                 new DbType[8] { DbType.Int32, DbType.Int32, DbType.String, DbType.Boolean, DbType.Boolean, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);

            return dtResult;
        }

        /// <summary>
        /// Получение данных о доступе отдела к отделам
        /// </summary>
        /// <param name=""></param>
        /// <returns>Таблица с данными</returns>        
        public async Task<DataTable> getDepartmentsAccessView(int id_Departments)
        {
            ap.Clear();
            ap.Add(id_Departments);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_getDepartmentsAccessView]",
                 new string[1] { "@id_Departments"},
                 new DbType[1] {DbType.Int32 }, ap);

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

        public async Task<DataTable> setDepartmentsAccessView(int id, int id_Departments, int id_DepartmentsView, bool isActive, bool isDel, int result)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_Departments);
            ap.Add(id_DepartmentsView);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(result);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[ArchiveDoc].[spg_setDepartmentsAccessView]",
                 new string[7] { "@id", "@id_Departments", "@id_DepartmentsView", "@isActive", "@id_user", "@result", "@isDel" },
                 new DbType[7] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);

            return dtResult;
        }

        #endregion

    }
}

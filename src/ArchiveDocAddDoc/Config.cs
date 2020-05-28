using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveDocAddDoc
{
    class Config
    {
        public static Procedures hCntMain { get; set; } //осн. коннект

        public static string centralText(string str)
        {
            int[] arra = new int[255];
            int count = 0;
            int maxLength = 0;
            int indexF = -1;
            arra[count] = 0;
            count++;
            indexF = str.IndexOf("\n");
            arra[count] = indexF;
            while (indexF != -1)
            {
                count++;
                indexF = str.IndexOf("\n", indexF + 1);
                arra[count] = indexF;
            }
            maxLength = arra[1] - arra[0];
            for (int i = 1; i < count; i++)
            {
                if (maxLength < (arra[i] - arra[i - 1]))
                {

                    maxLength = arra[i] - arra[i - 1];
                    if (i >= 2)
                    {
                        maxLength = maxLength - 1;
                    }
                }
            }
            string newString = "";
            string buffString = "";
            for (int i = 1; i < count; i++)
            {
                if (i >= 2)
                {

                    buffString = str.Substring(arra[i - 1] + 1, (arra[i] - arra[i - 1] - 1));
                    buffString = buffString.PadLeft(Convert.ToInt32(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2) * 1.8));
                    //    buffString = buffString.PadRight(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2)*2);
                    newString += buffString + "\n";
                }
                else
                {
                    buffString = str.Substring(arra[i - 1], arra[i]);
                    buffString = buffString.PadLeft(Convert.ToInt32(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2) * 1.8));
                    // buffString = buffString.PadRight(buffString.Length + ((maxLength - (arra[i] - arra[i - 1])) / 2)*2);
                    newString = buffString + "\n";
                }

            }

            return newString;
        }

        public static void DoOnUIThread(MethodInvoker d, Form _this)
        {
            if (_this.InvokeRequired) { _this.Invoke(d); } else { d(); }
        }
    }

    public class docInfo
    {
        public string nameDoc { set; get; }
        public string fileName { set; get; }
        public string fileNameWithOutExtension { set; get; }
        public byte[] fileBytes { set; get; }
    }

    public class transferDocuments
    {
        public transferDocuments()
        {
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
        }

        public bool getStatusDocuments(int id_Documents, int id_Status)
        {
            Task<DataTable> task = Config.hCntMain.getStatusDocumentsThisMoment(id_Documents, id_Status);
            task.Wait();
            if (task.Result == null || task.Result.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось получить данные","Проверка статуса записи",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            int idResult = (int)task.Result.Rows[0]["id"];

            if(idResult==-1)
            {
                MessageBox.Show("Запись удалена", "Проверка статуса записи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idResult == 1)
            {
                MessageBox.Show(Config.centralText("Нет возможности сменить статус\nне соответствие условию смены\n!"), "Проверка статуса записи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public bool deleteDocuments(int id_Documents)
        {
            Task<DataTable> task = Config.hCntMain.setDocuments(id_Documents, "", "", null, 0, true, 0);
            task.Wait();

            DataTable dtResult = task.Result;

            if (task.Result == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int result = (int)task.Result.Rows[0]["id"];

            if (result == -1)
            {
                MessageBox.Show(Config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            if (result == -2)
            {
                MessageBox.Show(Config.centralText("Нет возможности сменить статус\nне соответствие условию смены\n!"), "Проверка статуса записи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (DialogResult.Yes == MessageBox.Show("Удалить выбранную запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {

                task = Config.hCntMain.setDocuments(id_Documents, "", "", null, 0, true, 1);
                task.Wait();

                if (task.Result == null || task.Result.Rows.Count > 0)
                {
                    MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            return false;
        }

        public bool setStatusDocument(int id_Documents,int id_status)
        {
            Task<DataTable> task = Config.hCntMain.getDocuments_vs_DepartmentsPosts(id_Documents);
            task.Wait();

            if (task.Result == null)
            {
                MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DataTable dtData = task.Result;

            foreach (DataRow row in dtData.Rows)
            {
                task = Config.hCntMain.setDocuments_vs_DepartmentsPosts(
                    (int)row["id"],
                        (string)row["ArchiveComment"],
                        (string)row["BaseDocumentsArchive"],
                        (int)row["id_DepartmentsPosts"],
                        id_Documents,
                        id_status,
                        (bool)row["isBrowse"],
                        false,
                        0
                    );

                task.Wait();

                if (task.Result == null)
                {
                    MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}

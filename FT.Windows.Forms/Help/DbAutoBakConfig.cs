using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;
using System.IO;
using System.Windows.Forms;

namespace FT.Windows.Forms
{
    [Serializable]
    public class DbAutoBakConfig
    {
        public bool AutoBak = true;

        public int BakCount = 5;

        //public int Days = 1;

        public bool BakDb()
        {
            bool result = false;
            try
            {
                string exePath = ReflectHelper.GetExePath();
                string path = Path.Combine(exePath, "dbbak");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles();
                if (files.Length >= BakCount)
                {
                    DateTime first = files[0].CreationTime;
                    int index = 0;
                    for (int i = 1; i < files.Length; i++)
                    {
                        if (files[i].CreationTime < first)
                        {
                            first = files[i].CreationTime;
                            index = i;
                        }
                    }
                    files[index].Delete();
                    File.Copy("db\\db.mdb", "dbbak\\dbbak" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak");
                }
                else
                {
                    File.Copy("db\\db.mdb", "dbbak\\dbbak" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak");
                }
                result = true;
            }
            catch (Exception ex)
            {
               
            }
            return result;
        }
        public bool RestoreDb()
        {
            bool result = false;
            string exePath = ReflectHelper.GetExePath();
            string path = Path.Combine(exePath, "dbbak\\db.bak");
            string bakpath = FileDialogHelper.OpenBakDb(path);
            if (bakpath != null && bakpath != string.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show("ȷ��Ҫ��ԭ�����ڻ�ԭǰ���б��ݣ�", "������ʾ", MessageBoxButtons.YesNo))
                {
                    try
                    {
                        File.Copy(bakpath, ReflectHelper.GetExePath() + @"\db\db.mdb", true);
                        result = true;
                        MessageBoxHelper.Show("��ԭ�ɹ�,���˳�ϵͳ�ؽ���");
                    }
                    catch (Exception ex)
                    {
                        //LogFactoryWrapper.Debug(ex.ToString());
                        MessageBoxHelper.Show("��ԭʧ�ܣ�");
                    }
                }

            }
            return result;
        }
    }
}

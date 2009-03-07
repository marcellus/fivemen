using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FT.Commons.Tools;

namespace DS.Plugins.Student
{
    /// <summary>
    /// ���еĴ�ӡ����
    /// </summary>
    [Serializable]
    public class AllPrinterConfig
    {
        private static AllPrinterConfig instance=null;

        private const string FileName="printer.cfg";

        public static void BackUp()
        {
            string path = FileDialogHelper.SaveConfig();
            if (path != null && path != string.Empty)
            {
                try
                {
                    File.Copy(ReflectHelper.GetExePath() + @"\config\" + FileName, path, true);
                    MessageBoxHelper.Show(" ���ݳɹ���");
                }
                catch (Exception ex)
                {
                   
                    MessageBoxHelper.Show(" ����ʧ�ܣ��쳣��" + ex.Message);
                }
            }
        }

        public static void Restore()
        {
            string path = FileDialogHelper.OpenConfig();
            if (path != null && path != string.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show("ȷ��Ҫ��ԭ�����ڻ�ԭǰ���б��ݣ�", "������ʾ", MessageBoxButtons.YesNo))
                {
                    try
                    {
                        File.Copy(path, ReflectHelper.GetExePath() + @"\config\"+FileName, true);
                        MessageBoxHelper.Show("��ԭ�ɹ���");
                        Load();
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBoxHelper.Show("��ԭʧ�ܣ��쳣��"+ex.Message);
                    }
                }

            }
        }

        public static AllPrinterConfig GetPrinterConfig()
        {
            if (instance == null)
            {
                string path=Application.StartupPath+"/config/"+FileName;
                if (File.Exists(path))
                {
                    instance = (AllPrinterConfig)SerializeHelper.DeserializeFromFile(path);
                    if (instance.SysConfig == null)
                    {
                        instance.SysConfig = new SystemConfig();
                    }
                }
                else
                {
                    instance = new AllPrinterConfig();
                    instance.ApplyConfig = new ApplyPrinterConfig();
                    instance.F2Config = new F2PrinterConfig();
                    instance.F3Config = new F3PrinterConfig();
                    instance.F4Config = new F4PrinterConfig();
                    instance.F6Config = new F6PrinterConfig();
                    instance.SysConfig = new SystemConfig();
                }
            }
            return instance;
        }

        public static void Load()
        {
            string path = Application.StartupPath + "/config/" + FileName;
            instance=  (AllPrinterConfig)SerializeHelper.DeserializeFromFile(path);
        }

        public static void Save()
        {
             string path = Application.StartupPath + "/config/" + FileName;
             SerializeHelper.SerializeToFile(instance, path);
        }

        public ApplyPrinterConfig ApplyConfig;

        public F2PrinterConfig F2Config;

        public F3PrinterConfig F3Config;

        public F4PrinterConfig F4Config;

        public F6PrinterConfig F6Config;

        public SystemConfig SysConfig;

        public ShareDbConfig ShareConfig;
    }
}

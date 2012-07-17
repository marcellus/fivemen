using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FT.Commons.Tools;
using System.Diagnostics;

namespace FT.Commons.WindowsService.SystemInfo
{
    public class MonitorFileInfo
    {
        public string System;
        public string SystemVersion;
        public string FileName;
        public string FileVersion;
        public string RelativePath;
        public string Md5;
        public string FileSize;

        public MonitorFileInfo(string system,string systemVersion,string dirPath,FileInfo file)
        {
            this.System = system;
            this.SystemVersion = systemVersion;
            this.RelativePath = file.FullName.Substring(dirPath.Length + 1);
            this.Md5 = FileHelper.GetFileMd5(file.FullName);
            this.FileName = file.Name;
            FileVersionInfo version=FileVersionInfo.GetVersionInfo(file.FullName);
            this.FileVersion = version.FileVersion==null?"":version.FileVersion.Trim();
            
            this.FileSize = file.Length.ToString();
        }

        public override string ToString()
        {
            return string.Format("系统{0}版本{1},相对文件路径{2},文件名{3},文件版本：{6},文件大小为{4}字节,文件散列值为{5}",
                System,SystemVersion,RelativePath,FileName,FileSize,Md5,FileVersion);
        }
    }
}

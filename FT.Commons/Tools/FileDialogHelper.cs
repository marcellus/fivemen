/********************************************************************************
* File:FileDialogHelper.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Design;
using System.ComponentModel;


namespace FT.Commons.Tools
{
    ///<summary>
    ///Class <c>FileDialogHelper</c>
    ///Description:文件打开保存的帮助工具类
    ///</summary>
    public class FileDialogHelper : BaseHelper
    {
        public static string OpenDir()
        {
            return OpenDir(string.Empty);
        }

        public static string OpenDir(string selectedPath)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择路径";
            dialog.SelectedPath = selectedPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            else
            {
                return string.Empty;
            }
        }

        ///<summary>
        ///Initializes a new instance of the <see cref="FileDialogHelper"/> class.
        ///</summary>
        private FileDialogHelper()
        {
        }
        private static string ExcelFilter = "Excel(*.xls)|*.xls|All File(*.*)|*.*";

        /// <summary>
        /// 打开Excel对话框
        /// </summary>
        /// <returns></returns>
        public static string OpenExcel()
        {
            return Open("Excel选择", ExcelFilter);
        }

        /// <summary>
        /// 保存Excel对话框,并返回保存全路径
        /// </summary>
        /// <returns></returns>
        public static string SaveExcel()
        {
            return SaveExcel(string.Empty);
        }

        /// <summary>
        /// 保存Excel对话框,并返回保存全路径
        /// </summary>
        /// <returns></returns>
        public static string SaveExcel(string filename)
        {
            return Save("保存Excel", ExcelFilter,filename);
        }

        private static string ImageFilter = "Image Files(*.BMP;*.bmp;*.JPG;*.jpg;*.GIF;*.gif)|(*.BMP;*.bmp;*.JPG;*.jpg;*.GIF;*.gif)|All File(*.*)|*.*";

        /// <summary>
        /// Opens the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static string Open(string title, string filter,string filename)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            dialog.Title = title;
            dialog.RestoreDirectory = true;
            dialog.FileName = filename;
            // dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            else
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// Opens the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static string Open(string title,string filter)
        {

            return Open(title, filter, string.Empty);

        }

        /// <summary>
        /// Opens the Zip.
        /// </summary>
        /// <returns></returns>
        public static string OpenZip(string filename)
        {
            return Open("压缩文件选择", "Zip(*.zip)|*.zip",filename);
        }

        /// <summary>
        /// Save the Zip
        /// </summary>
        /// <returns></returns>
        public static string SaveZip(string filename)
        {
            return Save("压缩文件保存", "Zip(*.zip)|*.zip",filename);
        }

        /// <summary>
        /// Opens the image.
        /// </summary>
        /// <returns></returns>
        public static string OpenImage()
        {
           return Open("图片选择", ImageFilter);
        }

        /// <summary>
        /// Saves the specified tile.
        /// </summary>
        /// <param name="tile">The tile.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static string Save(string title, string filter,string filename)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = filter;
            dialog.Title = title;
            dialog.FileName = filename;
            dialog.RestoreDirectory = true;
            // dialog.ShowDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }

        /// <summary>
        /// 保存图片对话框并设置默认文件名,并返回保存全路径
        /// </summary>
        /// <returns></returns>
        public static string SaveImageWithName(string filename)
        {
            return Save("保存图片", ImageFilter,filename);
        }

        /// <summary>
        /// Saves the specified tile.
        /// </summary>
        /// <param name="tile">The tile.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static string Save(string title, string filter)
        {
            return Save(title, filter, string.Empty);
        }


       

        /// <summary>
        /// 保存图片对话框,并返回保存全路径
        /// </summary>
        /// <returns></returns>
        public static string SaveImage()
        {
            return Save("保存图片", ImageFilter);
        }

        private static string AccessFilter = "Access(*.mdb)|*.mdb|All File(*.*)|*.*";
        /// <summary>
        /// 保存数据库备份对话框
        /// </summary>
        /// <returns>数据库备份路径</returns>
        public static string SaveAccessDb()
        {
            return Save("数据库备份", AccessFilter);
        }

        public static string SaveBakDb()
        {
            return Save("数据库备份", "Access(*.bak)|*.bak");
        }

      
        public static string OpenBakDb(string file)
        {
            return Open("数据库还原", "Access(*.bak)|*.bak",file);
        }


        /// <summary>
        /// 数据库还原对话框
        /// </summary>
        /// <returns>数据库还原路径</returns>
        public static string OpenAccessDb()
        {
            return Open("数据库还原", AccessFilter);
        }

        private const string ConfigFilter = "配置文件(*.cfg)|*.cfg|All File(*.*)|*.*";
        /// <summary>
        /// 保存配置文件备份对话框
        /// </summary>
        /// <returns>配置文件备份路径</returns>
        public static string SaveConfig()
        {
            return Save("配置文件备份", ConfigFilter);
        }

        /// <summary>
        /// 配置文件还原对话框
        /// </summary>
        /// <returns>配置文件还原路径</returns>
        public static string OpenConfig()
        {
            return Open("配置文件还原", ConfigFilter);
        }
    }
}
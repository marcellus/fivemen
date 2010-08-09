using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using FT.Commons.Tools;
using System.IO;

namespace FT.Commons.Com.WordSupport
{
    /// <summary>
    /// 简单的Word操作对象
    /// </summary>
    public class SimpleWord
    {
        /// <summary>
        /// com对象常用的参数
        /// </summary>
       public static object Miss_Object = System.Reflection.Missing.Value;

       public static void Printview(string path)
       {
           if (!File.Exists(path))
           {
               return;
           }
           Document doc = null;
           Application app = new ApplicationClass();
           object refPath = path;
           doc = app.Documents.Add(ref refPath, ref Miss_Object, ref Miss_Object, ref Miss_Object);
           try
           {
               app.Visible = true;
               doc.PrintPreview();

           }
           catch (System.Exception e)
           {

           }
           finally
           {
               object saveChange = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
               if (doc != null)
                   doc.Close(ref saveChange, ref Miss_Object, ref Miss_Object);
               if (app != null)
                   app.Quit(ref Miss_Object, ref Miss_Object, ref Miss_Object);

           }
       }

       public static void Print(string path)
       {
           if(!File.Exists(path))
           {
               return;
           }
           Document doc = null;
           Application app = new ApplicationClass();
           object refPath = path;
           doc = app.Documents.Add(ref refPath, ref Miss_Object, ref Miss_Object, ref Miss_Object);
           try
           {
               doc.PrintOut(ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object,
                   ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object,
                   ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object,
                   ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
             

           }
           catch (System.Exception e)
           {
               throw e;
           }
           finally
           {
               object saveChange = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
               if (doc != null)
                   doc.Close(ref saveChange, ref Miss_Object, ref Miss_Object);
               if (app != null)
                   app.Quit(ref Miss_Object, ref Miss_Object, ref Miss_Object);

           }


       }
       /// <summary>
       /// 合并word文档
       /// </summary>
       /// <param name="orgs">需要合并的文档路径</param>
       /// <param name="dest">目标文档</param>
       public static void Combine(string[] orgs, ref object dest)
       {
           if (orgs != null&&orgs.Length>=2)
           {
               ApplicationClass oWordApplic = new ApplicationClass();
               Document oDoc;
               //,saveDoc;
               object readOnly = false;
               object isVisible = true;
               object fileName = orgs[0];
               oDoc=oWordApplic.Documents.Open(ref fileName, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
               oWordApplic.Selection.WholeStory();
               oWordApplic.Selection.Copy();
               oWordApplic.Selection.Paste();
               System.Windows.Forms.Clipboard.Clear();
               //oWordApplic.Selection.MoveEnd(ref Miss_Object, ref Miss_Object);
               
              // saveDoc = oWordApplic.Documents.Add(ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
              // saveDoc = oWordApplic.Documents.Open(ref template, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
             // object fileName = null;

               string tempFile = string.Empty;
               object confirmConversion = false;
               object link = false;
               object attachment = false;
               object wdline = Microsoft.Office.Interop.Word.WdUnits.wdLine;
               object count = 1;
               
               for (int i = 1; i <orgs.Length; i++)
               {

                   /*
                   fileName=orgs[i];
                   if (i > 0)
                   {
                       oWordApplic.Selection.EndKey(ref Miss_Object, ref Miss_Object);
                       oWordApplic.Selection.InsertBreak(ref Miss_Object);
                   }
                   oDoc = oWordApplic.Documents.Open(ref fileName , ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
                   oDoc.Activate();
                   oWordApplic.Selection.WholeStory();
                   oWordApplic.Selection.Copy();
                   saveDoc.Activate();
                   oWordApplic.Selection.Paste();
                   oDoc.Close(ref Miss_Object, ref Miss_Object, ref Miss_Object);
                   GC.SuppressFinalize(oDoc);
                   oDoc = null;
                   */
                  
                   tempFile = orgs[i];
                   //oWordApplic.Selection.m
                  
                  // oWordApplic.Selection.EndKey(ref Miss_Object, ref Miss_Object);
                   
                   oWordApplic.Selection.InsertBreak(ref Miss_Object);
                  
                   //oWordApplic.Selection.InsertBefore("\r");
                  // oWordApplic.Selection.MoveUp(ref wdline, ref count,ref Miss_Object);
                   oWordApplic.Selection.InsertFile(tempFile, ref Miss_Object, ref confirmConversion, ref link, ref attachment);
                   
               }
               //saveDoc.SaveAs(ref dest, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
               //saveDoc.Close(ref Miss_Object, ref Miss_Object, ref Miss_Object);

               oDoc.SaveAs(ref dest, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
               oDoc.Close(ref Miss_Object, ref Miss_Object, ref Miss_Object);
               oWordApplic.Quit(ref Miss_Object, ref Miss_Object, ref Miss_Object);
               oWordApplic = null;
           }
           
       }
    }
}

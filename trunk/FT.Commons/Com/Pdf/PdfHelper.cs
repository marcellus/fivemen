using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;
using FT.Commons.Tools;

namespace FT.Commons.Com.Pdf
{
    public class PdfHelper
    {
        private string filename;

        public PdfHelper(string filename)
        {
            this.filename = filename;
        }
        private iTextSharp.text.Document doc;
        private iTextSharp.text.pdf.PdfWriter writer;
         

        public void Open()
        {
            if(doc==null)
            {
                doc = new Document();
                writer=PdfWriter.getInstance(doc, new FileStream(filename, FileMode.Create));
                doc.Open();
            }
        }

        public void AddTitle(string str)
        {
            string path = FileHelper.GetFontPath();
            path += "\\SIMSUN.TTC,1";
            BaseFont bfSun = BaseFont.createFont(path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bfSun, 16, iTextSharp.text.Font.BOLD); 
            AddString(str, font);

        }

        public void AddBody(string str)
        {
            string path=FileHelper.GetFontPath();
            path += "\\SIMSUN.TTC,1";
            BaseFont bfSun = BaseFont.createFont(path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bfSun, 10,iTextSharp.text.Font.NORMAL); 

            AddString(str, font);
        }


        public void AddString(string str ,iTextSharp.text.Font font)
        {
            if(doc!=null)
            {
                Paragraph myParagraph = new Paragraph(str, font);
                doc.Add(myParagraph);

               // Chunk chunk = new Chunk(str + "金鑫珠宝销售记录单Hello world", FontFactory.getFont(FontFactory.COURIER, 20, iTextSharp.text.Font.ITALIC, new iTextSharp.text.Color(255, 0, 0)));
              //  doc.Add(chunk);
            }
            
        }

        public void Close()
        {
            if (doc != null)
            {
               // writer.Close();
                doc.Close();
                doc = null;
            }

        }

    }
}

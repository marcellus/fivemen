using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Print;
using System.Drawing;

namespace FT.Commons.Print
{
    public class TemplatePrintObject : ObjectPrinter
    {
        private TemplateTextConfig config;
        public TemplatePrintObject(TemplateTextConfig config)
        {
            this.config = config;
        }

        public override int GetTotalPage()
        {
            return 1;
        }

        public override System.Drawing.Image Paint()
        {
            throw new NotImplementedException();
        }

        public override void PaintPrinter()
        {
            if (this.GetCurrentPage() == 1)
            {
                TemplateTextObject text;
                Font font;
                for (int i = 0; i < config.Lists.Count;i++ )
                {
                    text=config.Lists[i];
                    if (text.ImgPath.Length > 0)
                    {
                        Image _tmpImage = null;
                        if (text.ImgPath.StartsWith("http"))
                        {
                            try
                            {
                                // Open a connection
                                System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(text.ImgPath);

                                _HttpWebRequest.AllowWriteStreamBuffering = true;

                                // set timeout for 20 seconds (Optional)
                                _HttpWebRequest.Timeout = 20000;

                                // Request response:
                                System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse();

                                // Open data stream:
                                System.IO.Stream _WebStream = _WebResponse.GetResponseStream();

                                // convert webstream to image
                                _tmpImage = Image.FromStream(_WebStream);

                                // Cleanup
                                _WebResponse.Close();
                                _WebResponse.Close();
                            }
                            catch (Exception _Exception)
                            {
                                // Error
                                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());

                            }
                        }
                        else
                        {
                            _tmpImage = Image.FromFile(text.ImgPath);
                        }

                       
                        this.DrawImage(_tmpImage, new Point(text.Left, text.Top));
                    }
                    else
                    {
                        font = new Font(text.FontName, text.FontSize);

                        this.DrawStringHor(text.Content, font, new Point(text.Left, text.Top));
                    }
                }
            }
        }

    }
}

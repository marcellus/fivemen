using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Commons.Bar
{


    /// <summary>
    /// Code39：生成39条码
    /// </summary>
    public class Code39
    {
        //对应码表
        private static Hashtable Decode;
        private static Hashtable CheckCode;
        //每个字符间的间隔符
        private string SPARATOR = "0";
        public int WidthCU = 3;  //粗线和宽间隙宽度
        public int WidthXI = 1;  //细线和窄间隙宽度
        public int xCoordinate = 10;//75;  //条码起始坐标
        public int LineHeight = 30;

        public int topHeight=2;
        public int Height = 0;
        private int Width = 0;

        public Font titleFont = new Font("宋体", 8, FontStyle.Bold);

        public Code39()
        {
        }

        static Code39()
        {
            Decode = new Hashtable();
            Decode.Add("0", "000110100");
            Decode.Add("1", "100100001");
            Decode.Add("2", "001100001");
            Decode.Add("3", "101100000");
            Decode.Add("4", "000110001");
            Decode.Add("5", "100110000");
            Decode.Add("6", "001110000");
            Decode.Add("7", "000100101");
            Decode.Add("8", "100100100");
            Decode.Add("9", "001100100");
            Decode.Add("A", "100001001");
            Decode.Add("B", "001001001");
            Decode.Add("C", "101001000");
            Decode.Add("D", "000011001");
            Decode.Add("E", "100011000");
            Decode.Add("F", "001011000");
            Decode.Add("G", "000001101");
            Decode.Add("H", "100001100");
            Decode.Add("I", "001001101");
            Decode.Add("J", "000011100");
            Decode.Add("K", "100000011");
            Decode.Add("L", "001000011");
            Decode.Add("M", "101000010");
            Decode.Add("N", "000010011");
            Decode.Add("O", "100010010");
            Decode.Add("P", "001010010");
            Decode.Add("Q", "000000111");
            Decode.Add("R", "100000110");
            Decode.Add("S", "001000110");
            Decode.Add("T", "000010110");
            Decode.Add("U", "110000001");
            Decode.Add("V", "011000001");
            Decode.Add("W", "111000000");
            Decode.Add("X", "010010001");
            Decode.Add("Y", "110010000");
            Decode.Add("Z", "011010000");
            Decode.Add("-", "010000101");
            Decode.Add("%", "000101010");
            Decode.Add("$", "010101000");
            Decode.Add("*", "010010100");

            CheckCode = new Hashtable();
            CheckCode.Add("0", "0");
            CheckCode.Add("1", "1");
            CheckCode.Add("2", "2");
            CheckCode.Add("3", "3");
            CheckCode.Add("4", "4");
            CheckCode.Add("5", "5");
            CheckCode.Add("6", "6");
            CheckCode.Add("7", "7");
            CheckCode.Add("8", "8");
            CheckCode.Add("9", "9");
            CheckCode.Add("A", "10");
            CheckCode.Add("B", "11");
            CheckCode.Add("C", "12");
            CheckCode.Add("D", "13");
            CheckCode.Add("E", "14");
            CheckCode.Add("F", "15");
            CheckCode.Add("G", "16");
            CheckCode.Add("H", "17");
            CheckCode.Add("I", "18");
            CheckCode.Add("J", "19");
            CheckCode.Add("K", "20");
            CheckCode.Add("L", "21");
            CheckCode.Add("M", "22");
            CheckCode.Add("N", "23");
            CheckCode.Add("O", "24");
            CheckCode.Add("P", "25");
            CheckCode.Add("Q", "26");
            CheckCode.Add("R", "27");
            CheckCode.Add("S", "28");
            CheckCode.Add("T", "29");
            CheckCode.Add("U", "30");
            CheckCode.Add("V", "31");
            CheckCode.Add("W", "32");
            CheckCode.Add("X", "33");
            CheckCode.Add("Y", "34");
            CheckCode.Add("Z", "35");
            CheckCode.Add("-", "36");
            CheckCode.Add(".", "37");
            CheckCode.Add(",", "38");
            CheckCode.Add("$", "39");
            CheckCode.Add("/", "40");
            CheckCode.Add("+", "41");
            CheckCode.Add("%", "42");
        }
        //保存档
        public Boolean saveFile(string Code, string Title, bool UseCheck, bool ValidateCode)
        {
            string code39 = Encode39(Code, UseCheck, ValidateCode);
            if (code39 != null)
            {
                Bitmap saved = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(saved);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
                this.DrawBarCode39(code39, Title, g);
                //string path = ConfigurationSettings.AppSettings["ImagePath"];
                string path = string.Empty;
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "*.JPEG|*.JPEG|*.JPG|*.JPG";
                saveFile.ShowDialog();
                if (!saveFile.FileName.Equals(""))
                {
                    path = saveFile.FileName;
                }
                else
                {
                    return false;
                }
                string filename = path + Code + ".jpg";
                saved.Save(filename, ImageFormat.Jpeg);
                saved.Dispose();
                return true;
            }
            return false;
        }

        public Bitmap CreateBarCode(string code)
        {
            string temp=StandardCode(code);
            return this.CreateBarCode(code, temp, false, false);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="Code">要生成条码的內容</param>
        /// <param name="Title">要显示的标题</param>
        /// <param name="UseCheck">计算检查码</param>
        /// <returns></returns>
        public Bitmap CreateBarCode(string Code, string Title, bool UseCheck, bool ValidateCode)
        {
            string code39 = Encode39(Code, UseCheck, ValidateCode);
            if (code39 != null)
            {
                Bitmap saved = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(saved);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
                this.DrawBarCode39(code39, Title, g);
                return saved;
            }
            return null;
        }

        /// <summary>
        /// 标志化字符串
        /// </summary>
        /// <param name="code">字符串</param>
        /// <returns>标准化后的字符串</returns>
        private string StandardCode(string code)
        {
            if (code.Substring(0, 1) != "*")
            {
                code = "*" + code;
            }
            if (code.Substring(code.Length - 1, 1) != "*")
            {
                code = code + "*";
            }
            return code;
        }
        /***
        * Code:未编码的字符串
        *
        * **/
        private string Encode39(string Code, bool UseCheck, bool ValidateCode)
        {
            //bool UseStand = true;  //检查输入待编码字符是否标准格式（是否以*开始和结束）

            //保存备份资料
            string originalCode = Code;

            //为空不进行编码
            if (null == Code || Code.Trim().Equals(""))
            {
                return null;
            }
            //检查错误字符
            Code = Code.ToUpper();  //转为大写
            Regex rule = new Regex(@"[^0-9A-Z%$\-*]");
            if (rule.IsMatch(Code))
            {
                MessageBoxHelper.Show("编码中包含非法字符，目前仅支持字母,数字及%$-*符号！");
                return null;
            }
            //检查计算码
            if (UseCheck)
            {
                int Check = 0;
                //累计求和
                for (int i = 0; i < Code.Length; i++)
                {
                    Check += int.Parse((string)CheckCode[Code.Substring(i, 1)]);
                }
                //取模
                Check = Check % 43;
                //附加检测码
                if (ValidateCode)
                {
                    foreach (DictionaryEntry de in CheckCode)
                    {
                        if ((string)de.Value == Check.ToString())
                        {
                            Code = Code + (string)de.Key;
                            break;
                        }
                    }
                }
            }
            //标准化输入字符，增加起始标志*
            ////if (UseStand)
            //{
            //    if (Code.Substring(0, 1) != "*")
            //    {
            //        Code = "*" + Code;
            //    }
            //    if (Code.Substring(Code.Length - 1, 1) != "*")
            //    {
            //        Code = Code + "*";
            //    }
            //}

            Code=StandardCode(Code);
            //转换为39编码
            string Code39 = string.Empty;
            for (int i = 0; i < Code.Length; i++)
            {
                Code39 = Code39 + (string)Decode[Code.Substring(i, 1)] + SPARATOR;
            }
            //SizeF titleSize = g.MeasureString("1", titleFont);
           // int height = topHeight + LineHeight+(int)titleSize.Height;//定义图片高度   
            int width = xCoordinate;
            for (int i = 0; i < Code39.Length; i++)
            {
                if ("0".Equals(Code39.Substring(i, 1)))
                {
                    width += WidthXI;
                }
                else
                {
                    width += WidthCU;
                }
            }
            this.Width = width + xCoordinate;
            //this.Height = height;

            return Code39;
        }

        private void DrawBarCode39(string Code39, string Title, Graphics g)
        {
            SizeF titleSize = g.MeasureString("1", titleFont);
           // this.Height = topHeight + LineHeight+(int)titleSize.Height;//定义图片高度   
            bool UseTitle = true;  //条形码底部显示标题
            //int UseTTF = 1;  //使用TTF字体，方便显示中文，需要$UseTitle=1时才能生效
            if (Title.Trim().Equals(""))
            {
                UseTitle = false;
            }
            Pen pWhite = new Pen(Color.White, 1);
            Pen pBlack = new Pen(Color.Black, 1);
            int position = xCoordinate;

            string temp;
            
            for (int i = 0; i < Code39.Length; i++)
            {
                //绘制线条
                temp=Code39.Substring(i, 1);
                if ("0".Equals(temp))
                {
                    
                    for (int j = 0; j < WidthXI; j++)
                    {
                        g.DrawLine(pBlack, position + j, topHeight, position + j, topHeight + LineHeight);
                    }
                    position += WidthXI;
                    
                }
                else
                {
                    for (int j = 0; j < WidthCU; j++)
                    {
                        g.DrawLine(pBlack, position + j, topHeight, position + j, topHeight + LineHeight);
                    }
                    position += WidthCU;

                    
                }
                i++;
                //绘制间隔线
                if (i<Code39.Length&&"0".Equals(Code39.Substring(i, 1)))
                {
                    position += WidthXI;
                }
                else
                {
                    position += WidthCU;
                }
            }

            //显示标题
            if (UseTitle)
            {
               int perWidth = position / Title.Length;
                int nowHeight=topHeight + LineHeight + 2;
               for (int i = 0; i < Title.Length;i++ )
               {
                   g.DrawString(Title[i].ToString(), titleFont, Brushes.Black, xCoordinate+perWidth*i+(perWidth-(int)titleSize.Width)/2-2, nowHeight);
               }

               //g.DrawString(Title, titleFont, Brushes.Black, (Width - sf.Width) / 2, topHeight + LineHeight+2);
            }
            return;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FT.Commons.WebCatcher
{
    public class SimpleCatcher:BaseAbstractCatcher
    {
        private Regex reg;
        public SimpleCatcher()
        {
            reg = new Regex("<div class[\\s]*?=[\\s]*?\"[posttitle|postTitle]+\">"
                    + "(?:.|\\n)*?href=\"(.+)\">(.+)</a>");
        }
        public override void ParseOne(string url)
        {
            string source = this.GetPageSource(url);
            Match m = reg.Match(source);
            int matchCount = 0;
            StringBuilder sb = new StringBuilder("匹配结果：");
            while (m.Success)
            {
                matchCount++;
                sb.Append("\r\n 第" + matchCount.ToString() + "项：");
                this.Download(m.Groups[1].Value);
                sb.Append("|" + m.Groups[2].Value);
                //foreach (Group group in m.Groups)
                //{
                    //sb.Append("|" + group.Value);
                //}
                m = m.NextMatch();
            }
            Console.WriteLine(sb.ToString());
            //throw new Exception("The method or operation is not implemented.");
        }
        
    }
}

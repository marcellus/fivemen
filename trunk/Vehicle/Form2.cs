using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vehicle
{
    public partial class Form2 : Form
    {
        //private string key = "EC79BD25-2005-0221-8143-A5FF53C87FEB";
        private string key = "EC79BD25";
        public Form2()
        {
            InitializeComponent();
            this.textBox1.Text = "C206A00123194EDEBDDC83F9A9716F419C4846E88E5722A57661F6CD359692B1E0F806DF58DE733F78FFB6FA90FBA3AB120940452647B79D4C6E0B644585755757E2BAA1901063CB1B0F651265EB36688B85CBB23D622AEC576341F2AFBCF2C97E3520FFE39041092748B46B09FB6FFC6B9599B201D1275D34A73946C8B3334D8439BC84CF197E8F7237AF86415D9DA0887BA308437F0548AA57C8DCD441017222DBC4A86CE432B5277B008567A8B070C8D9695FC8ED1C9D217B3EC596E9F961FE9A673C7D254612362E8FB578B81D0C488642A6CF888D728308611D25D1EEA46176465CE622C2142AC59AC05BF2CA4C032613CE6CEDAE8D7B6774740EC90993F53DC284C4CEB1F80392C9842902C6FD0C55935A062211FAF95F36B72A7BB4D328CCD1B4E3F70F3BD91A07697C97DDC54CEDE883AAAB7F19DD78E983C379795CEC0C46AE92E9065370AC3FDA3E5BF9A3157F6432FB8001AAE9D346D5E290B91A6DFC1784FEE88F904933DA2A66D8F2F2977859EBF4CDB0B95939E974B6360D908A24A9AF91A83E0A66195ACC8801F9BEA9F42A17948A71FC";
        }
        FT.Commons.Security.ISecurity security;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Decrypt();
        }

        private void Decrypt()
        {
            //security = new FT.Commons.Security.KeySecurity(key);
            //this.textBox2.Text = security.Decrypt(this.textBox1.Text.Trim());
            string code = this.textBox1.Text.Trim();
            string ls_temp = string.Empty;
            string result = string.Empty;
            for (int i = 1; i <= code.Length/2; i++)
            {
                ls_temp = code.Substring((i - 1)*2, 2);
                ls_temp = Convert.ToString((char)( Hex2Long(ls_temp)));
                result += ls_temp;
            }
            /*int mid = code.Length / 2;
            string left = code.Substring(0, mid);
            string right = code.Substring(mid);
            
            
            for (int i = 1; i <= mid;i++ )
            {
                ls_temp = left.Substring(i - 1, 1) + right.Substring(i - 1, 1);
                ls_temp=Convert.ToString((char)(255 - Hex2Long(ls_temp)));
                result += ls_temp;
            }*/
            this.textBox2.Text = result;
            /*integer li_i, li_j
string ls_encchar,ls_encchar1,ls_encchar2,ls_unasstr = ''

li_j = len(field)/2
ls_encchar1 = left(field,li_j)
ls_encchar2 = right(field,li_j)
for li_i = 1 to li_j
	ls_encchar = mid(ls_encchar1,li_i,1) + mid(ls_encchar2,li_i,1)
	ls_unasstr = ls_unasstr + char(255 - gf_hex2long(ls_encchar))
next
return ls_unasstr

end function*/


            
        }

        private int Hex2Long(string hex)
        {
            /*
global function long gf_hex2long (string as_hex);//[of_hex2long(as_hex) returns a long]
string ls_hex
integer li_i,length
long result = 0

length = len(as_hex)
ls_hex = Upper(as_hex)
FOR li_i = 1 to length
   result += &
     (Pos ('123456789ABCDEF', mid(ls_hex, li_i, 1)) * &
     ( 16 ^  ( length - li_i )  ))
NEXT
RETURN */
            string ls_hex = hex.ToUpper();
            int result = 0;
            /*int len = hex.Length;
            string posstr = "123456789ABCDEF";
            int tmp = 0;
            for (int i = 1; i <= len;i++ )
            {
                tmp = posstr.IndexOf(ls_hex.Substring(i - 1, 1)) + 1;
                tmp=(int)(tmp*Math.Pow(16,(len-i)));
                
                result += tmp;
            }*/
            result = Convert.ToInt32(ls_hex, 16);
            return result;
        }
    }
}
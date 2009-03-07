using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DS.Plugins.Student
{
    public class F2Printer : BaseStudentPrinter
    {
        public F2Printer(StudentInfo student)
            : base(student)
        {
        }
        public override int GetTotalPage()
        {
            return 1;
            //return 3;
        }

        public override System.Drawing.Image Paint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

       

        public override void PaintPrinter()
        {
            if (this.GetCurrentPage() < 4)
            {
               
                //int height=(this.GetCurrentPage()-1)*1024-690;
                //int width = (this.GetCurrentPage() - 1) * 768 + 900;
                
                this.PrintF2();
            }
        }
    }
}

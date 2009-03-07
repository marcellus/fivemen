using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DS.Plugins.Student
{
    public class F3Printer : BaseStudentPrinter
    {
         public F3Printer(StudentInfo student)
            : base(student)
        {
        }
        public override int GetTotalPage()
        {
            return 1;
        }

        public override System.Drawing.Image Paint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void PaintPrinter()
        {
            if (this.GetCurrentPage() == 1)
            {
                this.PrintF3();
            }
        }
    }
}

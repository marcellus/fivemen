using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DS.Plugins.Student
{
    public class F6Printer : BaseStudentPrinter
    {
        public F6Printer(StudentInfo student)
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
                this.PrintF6();
            }
        }
    }
}

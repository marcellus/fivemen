using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    public class AllPrinter : BaseStudentPrinter
    {
        public AllPrinter(StudentInfo student)
            : base(student)
        {
        }
        public override int GetTotalPage()
        {
            return 4;
        }

        public override System.Drawing.Image Paint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void PaintPrinter()
        {
            if (this.GetCurrentPage()>1)
            {
                this.PrintF2();
            }
            else if (this.GetCurrentPage() == 1)
            {
                this.PrintF4();
            }
           
        }
    }
}

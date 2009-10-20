using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    
    public abstract class SynStudentInfoPlugin
    {
        protected FT.DAL.IDataAccess dataAccess;

        public SynStudentInfoPlugin(FT.DAL.IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public abstract bool AddStudent(StudentAllInfo info);

        public abstract bool DeleteStudent(StudentAllInfo info);

        public abstract bool UpdateStudent(StudentAllInfo info);
    }
}

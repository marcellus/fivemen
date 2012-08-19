using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    [Serializable]
    public class CityObject
    {
        private string mcityId;

        public string McityId
        {
            get { return mcityId; }
            set { mcityId = value; }
        }
        private string    id;

        public string Id
        {
          get { return id; }
          set { id = value; }
        }
        private string  name;
    

        public string Name
        {
          get { return name; }
          set { name = value; }
        }
    }

}

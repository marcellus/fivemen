using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    [Serializable]
    public class ProvinceObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<CityObject> citys = new List<CityObject>();

        public List<CityObject> Citys
        {
            get { return citys; }
            set { citys = value; }
        }
    }
}

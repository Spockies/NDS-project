using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.E.NDS
{
    class Courier:IComparable
    {
        private string name {get; set;}
        private bool active { get; set; }
        private List<string> customerNames;
        public Courier()
        {
            name = "";
            active = false;
            customerNames = null;
        }
        public Courier(string _name,bool _active,List<string> _customerNames)
        {
            name = _name;
            active = _active;
            customerNames = _customerNames;
        }
        public Courier(string _name, bool _active)
        {
            name = _name;
            active = _active;
            customerNames = new List<string>();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

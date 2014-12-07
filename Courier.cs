using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.E.NDS
{
    public class Courier : IComparable
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<string> CustomerNames { get; set; }
        public List<int> GeoCoverage { get; set; }
        public int CourierID { get; set; }


        public Courier()
        {
            Name = "";
            Active = false;
            CustomerNames = new List<string>();
            GeoCoverage = new List<int>();
            CourierID = -1;
        }
        public Courier(string _name, bool _active, List<string> _customerNames,List<int> _geoCover)
        {
            Name = _name;
            Active = _active;
            CustomerNames = _customerNames;
            GeoCoverage = _geoCover;
            CourierID = -1;
        }
        public Courier(string _name, bool _active)
        {
            Name = _name;
            Active = _active;
            CustomerNames = new List<string>();
            GeoCoverage = new List<int>();
            CourierID = -1;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public bool Equals(object o)
        {
            return true;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}

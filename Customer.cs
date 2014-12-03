using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.E.NDS
{
    class Customer:IComparable
    {
        private string name { get; set; }
        private string address{ get; set; }
        private List<Publication> publications{ get; set; }
        private decimal monthlyTotal { get; set; }
        private string courier { get; set; }
        private bool isActive { get; set; }
        private string notes { get; set; }
        private int geoRank { get; set; }
        //constructor
        public Customer()
        {
            name = "";
            address = "";
            publications = null;
            monthlyTotal = 0;
            courier = "";
            isActive = false;
            notes = "";
            geoRank = 0;
        }
        public Customer(string _name, string _address, List<Publication> _publications, decimal _monthlyTotal,
            string _courier, bool _active, string _note, int _rank)
        {
            name = _name;
            address = _address;
            publications = _publications;
            monthlyTotal = _monthlyTotal;
            courier = _courier;
            isActive = _active;
            notes = _note;
            geoRank = _rank;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

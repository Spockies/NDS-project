using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace S.E.NDS
{
    public class Publication : IComparable
    {
        public enum week { MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY, NA }
        public enum time { DAILY, WEEKLY, MONTHLY, NA }
        public string PublicationName { get; set; }
        public decimal Cost { get; set; }
        public time TimeOccurance { get; set; }
        public week WeekOccurance { get; set; }
        public int PubID { get; set; }


        //explicit constructor
        public Publication(string name, decimal price, week day, time occur)
        {
            PublicationName = name;
            Cost = price;
            TimeOccurance = occur;
            WeekOccurance = day;
            PubID = -1;
        }

        public Publication()
        {
            //default state
            PublicationName = "";
            Cost = 0;
            TimeOccurance = time.NA;
            WeekOccurance = week.NA;
            PubID = -1;
        }
        public bool Equals(object o)
        {
            if (PubID == (o as Publication).PubID)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return PublicationName;
        }



        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2.Model
{
    class Member
    {
        private string _name;
        private string _SSN;
        private int _uniqueID;

        //private int []_boats;

        public Member(string name, string ssn/*, int []boats*/)
        {
            Name = name;
            SSN = ssn;
            Random rnd = new Random();
            _uniqueID = rnd.Next(1, 1000000000);
            //Boats = boats;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string SSN
        {
            get
            {
                return _SSN;
            }

            set
            {
                _SSN = value;
            }
        }

        public int UniqueID
        {
            get
            {
                return _uniqueID;
            }
        }

        // Unsecure on how to work with arrays in this matter... May have to look at this later on.
        //public int []Boats
        //{
        //    get
        //    {
        //        return _boats;
        //    }

        //    set
        //    {
        //        _boats = value;
        //    }
        //}
    }
}
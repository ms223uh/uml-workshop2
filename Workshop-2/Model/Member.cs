﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2.Model
{

    [Serializable]
    class Member /*: ISearchInterface . Didn't get interface to work...*/
    {
        private string _name;
        private string _SSN;
        private int _uniqueID;
        private List<Boat> _boats = new List<Boat>();
        

        public Member(string name, string ssn, int uniqueID)
        {
            Name = name;
            SSN = ssn;
            UniqueID = uniqueID;

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

            set
            {
                

                if (UniqueID == 0)
                {
                    
                    Random rnd = new Random();
                    _uniqueID = rnd.Next(1, 10000);
                }
                else
                {
                    _uniqueID = value;
                }
            }
        }

        public List<Boat> Boats
        {
            get
            {
                return _boats;
            }
            set
            {
                _boats = value;
            }

        }
    }
}
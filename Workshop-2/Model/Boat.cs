using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2.Model
{

    [Serializable]
    class Boat
    {
        private string _boatType;
        private float _boatLength;

        public Boat(string boatType, float boatLength)
        {
            BoatType = boatType;
            BoatLength = boatLength;
        }


        public string BoatType
        {
            get
            {
                return _boatType;
            }

            set
            {
                _boatType = value;
            }
        }


        public float BoatLength
        {
            get
            {
                return _boatLength;
            }

            set
            {
                _boatLength = value;
            }
        }
    }
}

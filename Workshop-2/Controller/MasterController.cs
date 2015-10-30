using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;

namespace Workshop_2.Controller
{
    class MasterController
    {

        MemberDAL _memberDAL;
        LoginModel _loginModel;

        public MasterController()
        {
             _memberDAL = new Model.MemberDAL();
             _loginModel = new Model.LoginModel();
        }

        public bool userWantsToLogin(string username,string password)
        {
            return _loginModel.checkLoginCredentials(username, password);
        }

        /*Createmember()
         *Creates new member object -> saves to .bin-file
         */
        public void createMember(string c_fullName, string c_SSN, int uniqueID)
        {
           
            Model.Member member = new Model.Member(c_fullName, c_SSN, uniqueID);
            bool isUnique = false;
            Random rnd = new Random();

            if (_memberDAL.members.Count > 0)
            {
                while (!isUnique)
                {
                    isUnique = false;
                    foreach (Member m in _memberDAL.members)
                    {
                        if (m.UniqueID == member.UniqueID)
                        {
                            member.UniqueID = rnd.Next(1, 10000);
                            isUnique = false;
                            break;
                        }
                        else
                        {
                            isUnique = true;
                        }
                    }
                }
            }
             _memberDAL.members.Add(member);
             saveChange();
        }

        public void addBoat(string c_boatType, float c_length, Member m)
        {
            Model.Boat boat = new Model.Boat(c_boatType, c_length);
            m.Boats.Add(boat);
            saveChange();
        }

        public void saveChange()
        {
            _memberDAL.saveToFile();
        }
      

        public List<Member> wantsToSeeList()
        {
            return _memberDAL.readFromFile();
        }

        public void updateMember(string name, string ssn, Member m)
        {
            m.Name = name;
            m.SSN = ssn;
            saveChange();
        }

        public void deleteMember(Member m)
        {
            for(int i = 0; i<_memberDAL.members.Count; i++)
            {
                if(m.UniqueID == _memberDAL.members.ElementAt(i).UniqueID)
                {
                    _memberDAL.members.RemoveAt(i);
                }
            }
            saveChange();
        }

        public void editBoat(string boatType, float boatLength, Boat b)
        {
            b.BoatType = boatType;
            b.BoatLength = boatLength;

            saveChange();
        }
        public void deleteBoat(List<Boat> boats, Boat b)
        {
            boats.Remove(b);

            saveChange();
        }
    }
}
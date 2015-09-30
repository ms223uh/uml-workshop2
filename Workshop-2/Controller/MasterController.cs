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
       

        public MasterController()
        {
             _memberDAL = new Model.MemberDAL();
        }

        public void createMember(string c_fullName, string c_SSN, int uniqueID)
        {
           
             Model.Member member = new Model.Member(c_fullName, c_SSN, uniqueID);
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
            _memberDAL.saveMember();
        }
      

        public List<Member> wantsToSeeCompactList()
        {
            return _memberDAL.getList();
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
    }
}
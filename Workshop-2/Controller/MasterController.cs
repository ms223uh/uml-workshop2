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
           
             Model.Member member = new Model.Member(c_fullName, c_SSN, uniqueID, null);   
            _memberDAL.saveMember(member);
        }

        public Member addBoat(string c_boatType, float c_length, Member m)
        {
            Model.Boat boat = new Model.Boat(c_boatType, c_length);
            List<Boat> boats = new List<Boat>();
            boats.Add(boat);
            m.Boats = boats;
            
            return m;
        }



        public List<Member> wantsToSeeCompactList()
        {
            return _memberDAL.getList();
        }

        public void updateMember()
        {

        }
    }
}
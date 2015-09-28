using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;

namespace Workshop_2.Controller
{
    class MemberController
    {

        MemberModel _memberModel;
      

        public MemberController()
        {
             _memberModel = new Model.MemberModel();
        
        }

        public void createMember(string c_fullName, string c_SSN, int uniqueID)
        {
             Model.Member member = new Model.Member(c_fullName, c_SSN, uniqueID);

            
            _memberModel.saveMember(member);
        }

        public List<Member> wantsToSeeCompactList()
        {
            return _memberModel.getList();
        }

        public void updateMember()
        {

        }
    }
}
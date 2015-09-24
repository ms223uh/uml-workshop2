using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2.Controller
{
    class MemberController
    {

        Model.MemberModel _memberModel;

        public MemberController()
        {
             _memberModel = new Model.MemberModel();
        }

        public void createMember(string c_fullName, string c_SSN)
        {
             Model.Member member = new Model.Member(c_fullName, c_SSN);

            
            _memberModel.saveMember(member);
        }

        public void listMember()
        {
            //return IEnumerable<Model.Member>;
        }

        public void updateMember()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Workshop_2.Model
{
    class MemberModel
    {
        
        private string _dir;
        private string _fileName;
        public MemberModel()
        {
            string dir = Environment.CurrentDirectory + "../../../Model/Data/";
            string fileName = "Members.txt";
            _fileName = fileName;
            _dir = dir;
        }

        public bool saveMember(Member member)
        {
            //TODO: add member to list 
            Console.WriteLine(member.UniqueID);
           
            List<Member> members = new List<Member>();
            members.Add(member);

            string memberPath = Path.Combine(_dir, _fileName);
            
            

            using (StreamWriter memberFile = new StreamWriter(memberPath))
            {
                
                memberFile.WriteLine("Name: {0} SSN: {1} MemberID: {2}", member.Name, member.SSN, member.UniqueID);

                memberFile.Close();
            }
            
            return true;
            
        }
    }
}

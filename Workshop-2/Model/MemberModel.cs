using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Workshop_2.Model
{
    class MemberModel
    {
        
        public List<Member> members = new List<Member>();

        public string file = "members.bin";


        public MemberModel()
        {
            MemberCompactModel mcm = new MemberCompactModel();
            mcm.getList();
        }

        public void saveMember(Member member)
        {
            
            members.Add(member);
            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, members);
            
            stream.Close();

        }
    
    }
}

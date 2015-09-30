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
    class MemberDAL
    {
        
        public List<Member> members = new List<Member>();

        private string file = "members.bin";


        public MemberDAL()
        {
            getList();
        }

        public void saveMember()
        {

            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, members);
            
            stream.Close();

        }

        public List<Member> getList()
        {
          
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                members = (List<Member>)formatter.Deserialize(stream);
            }
            catch
            {
                Console.WriteLine("File is empty");
            }
            stream.Close();

            return members;

        }
    
    }
}

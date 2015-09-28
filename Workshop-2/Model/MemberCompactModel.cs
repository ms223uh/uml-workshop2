using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2.Model
{
    class MemberCompactModel : MemberModel
    {
        public List<Member> getList()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Read);

            members = (List<Member>)formatter.Deserialize(stream);

            stream.Close();

            return members;

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Controller;
using Workshop_2.View;

namespace Workshop_2
{
    class Program
    {
        static void Main(string[] args)
        {
           MemberController mc = new MemberController();
            MenuView mv = new MenuView(mc);

            mv.menu();
        }
    }
}

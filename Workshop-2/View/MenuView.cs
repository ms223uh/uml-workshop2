using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Controller;
using System.Threading;
using Workshop_2.Model;
namespace Workshop_2.View
{
    class MenuView
    {

        MemberController _mc;

        public MenuView(MemberController mc)
        {
            _mc = mc;
        }

        public void menu()
        {
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to Happy Pirate!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Select an option...");

                Console.WriteLine("[---------------------------------]");
                Console.WriteLine("  1. Create a Member");
                Console.WriteLine("  2. Select a Member");
                Console.WriteLine("  3. Read Compact List of Members");
                Console.WriteLine("  4. Read Verbose List of Members");
                Console.WriteLine("  5. Edit Member");
                Console.WriteLine("  6. Delete Member");
                Console.WriteLine("  Q. Quit");
                Console.WriteLine("[---------------------------------]");


                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        Console.WriteLine("You Selected 'Create a Member'");
                        newMember();
                        Console.WriteLine("Member Added!");
                        Thread.Sleep(2000);
                       
                        break;
                    case '2':
                        Console.WriteLine("You Selected 'Select a Member'");
                        selectMember();
                        
                        break;
                    case '3':
                        Console.WriteLine("Compact List of Members'");
                        printCompactList();
                        break;
                    case '4':
                        throw new NotImplementedException();
                        //Console.WriteLine("TODO: 'Read Verbose List of Members'");
                        //break;
                    case '5':
                        throw new NotImplementedException();
                        //Console.WriteLine("TODO:  'Edit a Member'");
                        //break;
                    case '6':
                        throw new NotImplementedException();
                        //Console.WriteLine("TODO:  'Delete a Member'");
                        //break;
                    case 'q':
                        Console.Clear();
                        Console.WriteLine("Have a nice day!");
                        Environment.Exit(0);
                        break;
                        
                }
                Console.Clear();
            }
        }
        public void newMember()
        {
            Console.Clear();

            Console.Write("CREATE A MEMBER");

            //Name
            Console.WriteLine("");
            Console.Write("Enter the fullname of the member: ");
            string v_fullName = Console.ReadLine();

            //SSN
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXX-XXXX");
            Console.Write("Enter the members Social Security Number: ");
            string v_SSN = Console.ReadLine();

            _mc.createMember(v_fullName, v_SSN, 0);
        }

        public void selectMember()
        {
            Console.Clear();
            Console.WriteLine("SELECT A MEMBER");

            Console.Write("Enter the SSN of the Member :");
            string v_ssnInput = Console.ReadLine();

        }

        public void printCompactList()
        {
            List<Member> members = _mc.wantsToSeeCompactList();
            Console.Clear();
            foreach(Member m in members)
            {
                Console.WriteLine("Name: {0} SSN: {1} ID: {2}", m.Name, m.SSN, m.UniqueID);
            }
            Console.WriteLine("Press any key to go back");
            Console.ReadLine();

        }

    }
}
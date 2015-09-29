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

        MasterController _mc;

        public MenuView(MasterController mc)
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
                Console.WriteLine("  Q. Quit");
                Console.WriteLine("[---------------------------------]");


                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        Console.WriteLine("You Selected 'Create a Member'");
                        newMember();
                        Console.WriteLine("Member Added!\nPress any key to continue.");
                        Console.ReadLine();
                       
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
            Console.Write("\nEnter the fullname of the member: ");
            string v_fullName = Console.ReadLine();

            //SSN
            Console.WriteLine("\n                                          XXXXXX-XXXX");
            Console.Write("Enter the members Social Security Number: ");
            string v_SSN = Console.ReadLine();

                _mc.createMember(v_fullName, v_SSN, 0);
        }

        public void selectMember()
        {
            Console.Clear();
            printCompactList();
            Console.WriteLine("\nSELECT A MEMBER");

            Console.Write("Enter the UniqueID of the Member :");
            int select = int.Parse(Console.ReadLine());

            List<Member> members = _mc.wantsToSeeCompactList();



            foreach(Member m in members)
            {
                if(select == m.UniqueID)
                {
                    selectedMember(m);
                    
                }
            }

        }

        public void selectedMember(Member m)
        {
            Console.Clear();
            Console.WriteLine("You have selected '{0}'", m.Name);
                        
            Console.WriteLine("\nWhat do you want to do with your selected member?");
           
            Console.WriteLine("1. Add Boat");
            Console.WriteLine("2. Edit Boat");
            Console.WriteLine("3. Delete Boat");
            Console.WriteLine("4. Edit Member");
            Console.WriteLine("5. Delete Member");

            char choice = Console.ReadKey().KeyChar;
            switch (choice){
                case'1' :
                    
                    addBoat(m);
                    break;
                case'2' : 
                    break;
                case'3' :
                    break;
                case '4':
                    break;
                case '5':
                    break;
            };

           
        }

        public void addBoat(Member m)
        {
            //BOATS
            Console.Clear();
            Console.Write("\nEnter the amount of boats: ");
            int v_numberOfBoats = int.Parse(Console.ReadLine());

            for (int i = 0; i < v_numberOfBoats; i++)
            {
                Console.Clear();
                Console.WriteLine("Select Which type:");
                Console.WriteLine("1. Sailboat");
                Console.WriteLine("2. Motorsailer");
                Console.WriteLine("3. Kayak/Canoe");
                Console.WriteLine("4. Other");

                char v_boatChoice = Console.ReadKey().KeyChar;
                string v_boatType = "";

                if (v_boatChoice == '1')
                {
                    v_boatType = "Sailboat";
                }
                if (v_boatChoice == '2')
                {
                    v_boatType = "Motorsailer";
                }
                if (v_boatChoice == '3')
                {
                    v_boatType = "Kayak/Canoe";
                }
                if (v_boatChoice == '4')
                {
                    v_boatType = "Other";
                }


                Console.Clear();
                Console.WriteLine("You've selected the type: {0}", v_boatType);
                Console.Write("Enter the length of the boat (metric): ");
                float v_boatLength = float.Parse(Console.ReadLine());

             _mc.addBoat(v_boatType, v_boatLength, m);
            }
            //TODO: SAVE MEMBER WITH BOAT TO FILE. GGWP, hard actually.
        }

        public void printCompactList()
        {
            List<Member> members = _mc.wantsToSeeCompactList();
            Console.Clear();
            Console.WriteLine(String.Format("{0,-20} {1,-13} {2,-8} {3}", "NAME", "SSN", "UID","BOATS"));
            foreach(Member m in members)
            {
                Console.WriteLine(String.Format("{0,-19}| {1,-10} | {2,-4} | {3,-10}", m.Name, m.SSN, m.UniqueID, m.Boats.Count));
            }
            //Console.WriteLine("Press any key to go back");
            //Console.ReadLine();

        }

    }
}
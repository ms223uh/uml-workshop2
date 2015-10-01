using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Controller;
using System.Threading;
using Workshop_2.Model;
using System.Text.RegularExpressions;
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
            Console.Clear();
            while(true)
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WELCOME TO HAPPY PIRATE'S MEMBER REGISTRY!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Select an option...");

                Console.WriteLine("[---------------------------------]");
                Console.WriteLine("  1. Create a Member");
                Console.WriteLine("  2. Select a Member");
                Console.WriteLine("  3. Read Compact List of Members");
                Console.WriteLine("  4. Read Verbose List of Members");
                Console.WriteLine("\n  Q. Quit");
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
                        Console.WriteLine("Compact List of Members'");
                        printVerboseList();
                        break;

                    case 'q':
                        Console.Clear();
                        Console.WriteLine("Have a nice day!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You need to enter a valid number! Press Enter to try again.");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.Clear();
            }
        }


        /*
         *  Member Handling.
         */
        public void newMember()
        {
            Console.Clear();
            Console.Write("[CREATE A MEMBER]");
            string v_fullName = credentialsName();
            string v_SSN = credentialsSSN();
            _mc.createMember(v_fullName, v_SSN, 0);


           
        }

        public void editMember(Member m)
        {
            Console.Clear();
            Console.WriteLine("[EDIT MEMBER ({0})]", m.Name);
            string changedName = credentialsName();
            string changedSSN = credentialsSSN();

            _mc.updateMember(changedName, changedSSN, m);
        }

        public void deleteMember(Member m)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you really want to delete {0}? (y/n)", m.Name);
                char selection = Console.ReadKey().KeyChar;

                if (selection == 'y')
                {
                    _mc.deleteMember(m);
                    Console.Clear();
                    Console.WriteLine("You have deleted {0}. Press Enter to go back to mainmenu.", m.Name);
                    Console.ReadLine();
                    menu();
                }
                else if (selection == 'n')
                {
                    break;
                }
            }
        }

        public string credentialsName()
        {
             
            //Name
            Console.Write("\nEnter the Firstname of the member: ");
            string v_firstName = Console.ReadLine();
            Console.Write("\nEnter the Lastname of the member: ");
            string v_lastName = Console.ReadLine();

            string v_fullName = v_firstName + " " + v_lastName;

            return v_fullName;
        }

        public string credentialsSSN()
        {
            string v_SSN;
            while (true)
            {

                Console.Write("\nEnter the members Social Security Number (XXXXXXXX-XXXX): ");
                Regex regexSSN = new Regex("^[12]{1}[90]{1}[0-9]{6}-[0-9]{4}$");
                v_SSN = Console.ReadLine();
                Match match = regexSSN.Match(v_SSN);

                if(match.Success)
                {
                    return v_SSN;
                }


                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid Social Secrurity Number. Press Enter to retry!");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                
            }
            
        }

        public void selectMember()
        {
            while (true)
            {
                Console.Clear();
                minimalMemberList();
                Console.WriteLine("\n[SELECT MEMBER]");

                Console.Write("Press the number of the Member (0 to go back) :");
                

                try
                {
                    int select = int.Parse(Console.ReadLine());

                    List<Member> members = _mc.wantsToSeeList();
                    if(select == 0)
                    {
                        menu();
                    }

                    foreach (Member m in members)
                    {
                        if (members.IndexOf(m) == select -1)
                        {
                            selectedMember(m);
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to enter a valid number! Press Enter to try again.");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public void selectedMember(Member m)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[YOU HAVE SELECTED: {0}]", m.Name);
                        
                Console.WriteLine("\nWhat do you want to do with your selected member?");
           
                Console.WriteLine("1. Add Boat");
                Console.WriteLine("2. Edit Boat");
                Console.WriteLine("3. Delete Boat");
                Console.WriteLine("4. Edit Member");
                Console.WriteLine("5. Delete Member");
                Console.WriteLine("\nB. Go back to menu");

                bool editOrDelete;
            
                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        addBoat(m);
                        break;

                    case '2':
                        editOrDelete = true;
                        editBoat(m, editOrDelete);
                        break;

                    case '3':
                        editOrDelete = false;
                        editBoat(m, editOrDelete);
                        break;

                    case '4':
                        editMember(m);
                        break;

                    case '5':
                        deleteMember(m);
                        break;
                    case 'b':
                        menu();
                        break;


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You need to enter a valid number! Press Enter to try again.");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                };
            }
            

           
        }


        /*
         *  Boat Handling.
         */
        public void addBoat(Member m)
        {
            Console.Clear();
            Console.WriteLine("[ADD BOAT]");
            Console.Write("\nEnter the amount of boats: ");
            try 
            {
                int v_numberOfBoats = int.Parse(Console.ReadLine());
            

                for (int i = 0; i < v_numberOfBoats; i++)
                {
                    string v_boatType = credentialBoatType();
                    float v_boatLength = credentialBoatLength(v_boatType);

                    _mc.addBoat(v_boatType, v_boatLength, m);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Enter a valid  number! Press Enter to go back.");
                Console.ReadLine();
            }
        }

        public void editBoat(Member m, bool editOrDelete)
        {
            Console.Clear();

            int pos = 0; 
             
            foreach(Boat boat in m.Boats)
            {
                Console.WriteLine(pos+". "+" Type: {0,-10}  Length: {1}m ",boat.BoatType, boat.BoatLength);
                pos++;
            }

            Console.Write("\nWhich boat do you want to edit?");
            try
            {
                int choice = int.Parse(Console.ReadLine());
         
                foreach(Boat boat in m.Boats)
                {
                    if (m.Boats.IndexOf(boat) == choice)
                    {
                        if(editOrDelete)
                        {
                            editSelectedBoat(boat);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You have successfully edited the boat!");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                            break;
                        }
                        else
                        {
                            deleteSelectedBoat(m.Boats, boat);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You have successfully removed the boat from the Member!");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid  number! Press Enter to go back.");
                Console.ReadLine();
            }
            
        }

        public void editSelectedBoat(Boat b)
        {
            string editedBoatType = credentialBoatType();
            float edtiedBoatLength = credentialBoatLength(editedBoatType);

            _mc.editBoat(editedBoatType, edtiedBoatLength, b);
        }

        public void deleteSelectedBoat(List<Boat> boats,Boat b)
        {
            _mc.deleteBoat(boats,b);
        }

        public string credentialBoatType()
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

                return v_boatType;            
        }

        public float credentialBoatLength(string v_boatType)
        {
            Console.Clear();
            Console.WriteLine("You've selected the type: {0}", v_boatType);
            Console.Write("Enter the length of the boat (metric): ");
            float v_boatLength = float.Parse(Console.ReadLine());

            return v_boatLength;
        }



        /*
         * PrintComapactList() - Prints: Name, UID and the amount of boats on each member.
         * PrintVerboseList()  - Prints: Name, SSN, UID and details on each boat for each member.
         * minimalMemberList() - Prints: Name
         */
        public void printCompactList()
        {
            List<Member> members = _mc.wantsToSeeList();
            Console.Clear();
            Console.WriteLine("[COMPACT LIST]\n");
            Console.WriteLine(String.Format("{0,-21} {1,-6} {2}", "NAME", "UID","BOATS"));
            Console.WriteLine("------------------------------------");
            foreach(Member m in members)
            {
                Console.WriteLine(String.Format("{0,-19} | {1,-4} | {2,-10}", m.Name, m.UniqueID, m.Boats.Count));
            }
            Console.WriteLine("\nPress Enter to go back");
            Console.ReadLine();
        }

        public void printVerboseList()
        {
            List<Member> members = _mc.wantsToSeeList();
            Console.Clear();
            Console.WriteLine("[VERBOSE LIST]\n");
            foreach (Member m in members)
            {
                
                Console.WriteLine(String.Format("{0,-30} {1,-14} {2} ", "NAME", "SSN", "UID"));
                
                Console.WriteLine(String.Format("{0,-30} {1,-13}  {2,-4}", m.Name, m.SSN, m.UniqueID));
                
                Console.WriteLine("\nBOATS");
                
                
                foreach(Boat b in m.Boats)
                {
                    Console.WriteLine(String.Format("{0,-15} {1} m", b.BoatType, b.BoatLength));
                }
                Console.WriteLine("-------------------------------------\n");
            }
            Console.WriteLine("\nPress Enter to go back");
            Console.ReadLine();
        }

        public void minimalMemberList()
        {
            List<Member> members = _mc.wantsToSeeList();
            int pos = 0;
            Console.Clear();
            Console.WriteLine("NAME");
            foreach (Member m in members)
            {
                Console.WriteLine("{0}: {1}",pos+1 , m.Name);
                pos++;
            }
        }

    }
}
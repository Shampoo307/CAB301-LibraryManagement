using System;

namespace CAB301_LibraryManagement
{
    class Program
    {


        static void Main(string[] args)
        {
            MemberCollection memberCollection = new MemberCollection();
            MovieCollection movieCollection = new MovieCollection();
            //MemberCollection.memberCollection = new MemberCollection();

            MainMenu(memberCollection, movieCollection);

            /*  Console.WriteLine("Creating new member......");
              Member member = new Member();
              member.RegisterMember();*/

        }

        public static void MainMenu(MemberCollection memberCollection, MovieCollection movieCollection)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Community Library\n"
                            + "============Main Menu===========\n"
                            + "1. Staff Login\n" 
                            + "2. Member Login\n"
                            + "0. Exit\n"
                            + "================================\n"
                            + "Please make a selection (1-2, or 0 to exit): ");
            string response = Console.ReadLine();
            
            if (response == "1")
            {
                bool isLoggedIn = StaffLogin();
                if (isLoggedIn)
                {
                    StaffMenu staffMenu = new StaffMenu();
                    staffMenu.Menu(memberCollection, movieCollection);
                } else
                {
                    Console.WriteLine("Incorrect login, press any key to return to menu...");
                    Console.ReadLine();
                    MainMenu(memberCollection, movieCollection);
                }
            } else if (response == "2")
            {
                int memberIndex = MemberLogin(memberCollection);
                if (memberIndex != -1)
                {
                    MemberMenu memberMenu = new MemberMenu();
                    memberMenu.Menu(memberCollection, memberIndex, movieCollection);
                }
                else
                {
                    Console.WriteLine("Incorrect login, press any key to return to menu...");
                    Console.ReadLine();
                    MainMenu(memberCollection, movieCollection);
                }

            } else if (response == "0")
            {

                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input, please make a selection (1-2, or 0 to exit.\n"
                                + "Press enter to continue...");

                Console.ReadLine();
                MainMenu(memberCollection, movieCollection);
            }
        }

        private static bool StaffLogin()
        {
            Console.Clear();
            Console.WriteLine("===========Staff Login==========\n"
                            + "Please enter your username: ");
            string staffUser = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string staffPass = Console.ReadLine();
            if (staffUser == StaffMenu.USER && staffPass == StaffMenu.PASS)
            {
                return true;
            }
            return false;
        }


        private static int MemberLogin(MemberCollection memberCollection)
        {
            Console.Clear();
            Console.WriteLine("==========Member Login==========\n"
                            + "Please enter your username (LastnameFirstname): ");
            string memberUser = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string memberPass = Console.ReadLine();
            int memberIndex = memberCollection.ValidateLogin(memberUser, memberPass);
            if (memberIndex == -1)
            {
                return -1;
            }
            return memberIndex;
        }
        

    }
}

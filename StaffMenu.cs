using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_LibraryManagement
{
    class StaffMenu
    { 
        
        public const string USER = "staff";
        public const string PASS = "today123";

        public void Menu(MemberCollection memberCollection, MovieCollection movieCollection)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Community Library\n"
                            + "===========Staff Menu===========\n"
                            + "1. Add a new movie DVD\n"
                            + "2. Remove a movie DVD\n"
                            + "3. Register a new Member\n"
                            + "4. Find a registered member's phone number\n"
                            + "0. Return to main menu\n"
                            + "================================\n"
                            + "Please make a selection (1-4, or 0 to return to main menu): ");
            string response = Console.ReadLine();
            if (response == "1")
            {
                AddDVD(movieCollection);
                Menu(memberCollection, movieCollection);
            }
            else if (response == "2")
            {
                RemoveDVD(movieCollection);
                Menu(memberCollection, movieCollection);
            }
            else if (response == "3")
            {
                RegisterMember(memberCollection);
                Menu(memberCollection, movieCollection);
            }
            else if (response == "4")
            {
                FindMemberPhone(memberCollection);
                Menu(memberCollection, movieCollection);
            }
            else if (response == "0")
            {
                Program.MainMenu(memberCollection, movieCollection);
            }
            else
            {
                Console.WriteLine("Invalid input, please make a selection (1-4, or 0) to return to main menu.\n"
                                + "Press enter to continue...");
                Console.ReadLine();
                Menu(memberCollection, movieCollection);
            }
        }

        public void AddDVD(MovieCollection movieCollection)
        {
            Movie newMovie = new Movie();
            newMovie.AddDVD();
            movieCollection.AddDVD(newMovie);

        }

        public void RemoveDVD(MovieCollection movieCollection)
        {
            Console.WriteLine("Please enter the name of the DVD being removed: ");
            string movieName = Console.ReadLine();
            if (movieCollection.MovieExists(movieName))
            {
                movieCollection.RemoveDVD(movieName);
                Console.WriteLine("{0} has been removed.\nPress any key to return to menu...", movieName);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("{0} is not a movie held in this library.\n"
                                + "Press any key to return to menu...", movieName);
            }
        }

        public void RegisterMember(MemberCollection memberCollection)
        {
            Member newMember = new Member();
            newMember.RegisterMember();
            if (memberCollection.MemberAlreadyExists(newMember))
            {
                Console.WriteLine("\nMember already exists.\n"
                                + "Please enter any key to return...");
                Console.ReadLine();
            }
            else
            {
                memberCollection.AddMember(newMember);
                Console.WriteLine("Member successfully registered.\n"
                                + "Press any key to return to Staff Menu");
                Console.ReadLine();
            }
        }

        

        public void FindMemberPhone(MemberCollection memberCollection)
        {
            Console.WriteLine("Please enter member's FIRST and LAST name: ");
            string fullName = Console.ReadLine();
            int memberIndex = memberCollection.SearchMembers(fullName);
            if (memberIndex >= 0)
            {
                Console.WriteLine("The member {0}'s phone number is: {1}\n",
                                fullName, memberCollection.members[memberIndex].ContactNumber);
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Member {0} was unable to be found.\n", fullName);
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadLine();
            }
        }


        
    }
}

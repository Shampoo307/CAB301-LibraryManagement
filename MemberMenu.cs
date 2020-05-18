using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_LibraryManagement
{
    class MemberMenu
    {
        public void Menu(MemberCollection memberCollection, int memberIndex, MovieCollection movieCollection)
        {
            Console.Clear();
            Console.WriteLine("==========Member Menu===========\n"
                            + "1. Display all movies\n"
                            + "2. Borrow a movie DVD\n"
                            + "3. Return a movie DVD\n"
                            + "4. List current borrowed movie DVDs\n"
                            + "5. Display top 10 most popular movies\n"
                            + "0. Return to main menu\n"
                            + "================================\n"
                            + "Please make a selection (1-5, or 0 to exit): ");
            string response = Console.ReadLine();
            if (response == "1")
            {
            }
            else if (response == "2")
            {
                BorrowDVD(memberCollection, memberIndex, movieCollection);
            }
            else if (response == "3")
            {
            }
            else if (response == "4")
            {
            }
            else if (response == "4")
            {
            }
            else if (response == "0")
            {
                Program.MainMenu(memberCollection, movieCollection);
            }
            else
            {
                Console.WriteLine("Invalid input, please make a selection (1-5, or 0 to return to main menu.\n"
                                + "Press enter to continue...");
                Console.ReadLine();
                Menu(memberCollection, memberIndex, movieCollection);
            }
        }


        public void BorrowDVD(MemberCollection memberCollection, int memberIndex, MovieCollection movieCollection)
        {
            if (memberCollection.members[memberIndex].NumDVDsBorrowed >= 10)
            {
                Console.WriteLine("\nSorry, you've already got 10 DVDs borrowed.\n"
                                + "Please return a DVD before borrowing another one.");
                return;
            }
            Console.WriteLine("Please enter the Movie TITLE: ");
            string movieTitle = Console.ReadLine();
            bool movieExists = movieCollection.MovieExists(movieTitle);
            if (movieExists)
            {
                memberCollection.members[memberIndex].DVDsBorrowed = Console.ReadLine();
                memberCollection.members[memberIndex].NumDVDsBorrowed++;
                movieCollection.BorrowDVD(movieTitle);
            }
            else
            {
                Console.WriteLine("\n{0} is not in the catalog.\n"
                                + "Press any key to return to menu...", movieTitle);
            }
            
        }

    }
}

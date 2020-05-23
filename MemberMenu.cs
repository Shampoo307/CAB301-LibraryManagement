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
                movieCollection.DisplayAll();
                Menu(memberCollection, memberIndex, movieCollection);
            }
            else if (response == "2")
            {
                BorrowDVD(memberCollection, memberIndex, movieCollection);
                Menu(memberCollection, memberIndex, movieCollection);
            }
            else if (response == "3")
            {
                ReturnDVD(memberCollection, memberIndex, movieCollection);
                Menu(memberCollection, memberIndex, movieCollection);
            }
            else if (response == "4")
            {
                DisplayBorrowed(memberCollection, memberIndex, movieCollection);
                Menu(memberCollection, memberIndex, movieCollection);
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
            if (memberCollection.members[memberIndex].NumDVDsBorrowed < 10)
            {
                Console.WriteLine("Please enter the Movie TITLE: ");
                string movieTitle = Console.ReadLine();

                if (movieCollection.MovieExists(movieTitle))
                {
                    if (movieCollection.Search(movieTitle).CopiesAvailable > 0)
                    {
                        memberCollection.members[memberIndex].BorrowDVD(movieTitle);
                        movieCollection.BorrowDVD(movieTitle);
                        Console.WriteLine("{0} Borrowed!\nPlease any key to return to menu...", movieTitle);
                    }
                    else
                    {
                        Console.WriteLine("There are no more copies of {0} available.", movieTitle);
                        Console.WriteLine("Press any key to return to menu...");
                    }
                }
                else
                {
                    Console.WriteLine("\n{0} is not in the catalog.\n"
                                    + "Press any key to return to menu...", movieTitle);
                }
            }
            else 
            {
                Console.WriteLine("\nSorry, you've already got 10 DVDs borrowed.\n"
                              + "Please return a DVD before borrowing another one.\n"
                              + "Please any key to return to menu...");
            }
            
            Console.ReadLine();
        }

        public void ReturnDVD(MemberCollection memberCollection, int memberIndex, MovieCollection movieCollection)
        {
            Console.WriteLine("Please enter the Movie TITLE: ");
            string movieTitle = Console.ReadLine();
            bool movieExists = movieCollection.MovieExists(movieTitle);
            if (movieExists)
            {
                memberCollection.members[memberIndex].ReturnDVD(movieTitle);
                memberCollection.members[memberIndex].NumDVDsBorrowed--;
                movieCollection.ReturnDVD(movieTitle);
            }
            else
            {
                Console.WriteLine("\n{0} is not in the catalog.\n"
                                + "Press any key to return to menu...", movieTitle);
            }

        }

        public void DisplayBorrowed(MemberCollection memberCollection, int memberIndex, MovieCollection movieCollection)
        {
            Console.WriteLine("Currently Borrowed: ");
            memberCollection.members[memberIndex].DisplayBorrowed(movieCollection);

        }

    }
}

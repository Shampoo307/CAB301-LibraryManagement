using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_LibraryManagement
{
    class Member
    {
       public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string FullName
        {
            get; set;
        }
        public string ContactNumber
        {
            get; set;
        }
        public int NumDVDsBorrowed
        {
            get; set;
        }
        public string DVDsBorrowed
        {
            get; set;
        }
        public bool ISRegistered
        {
            get; set;
        }

        public void RegisterMember()
        {

            Console.WriteLine("Please enter the Member's FIRST NAME: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Please enter the Member's LAST NAME: ");
            LastName = Console.ReadLine();

            FullName = FirstName + ' ' + LastName;

            Console.WriteLine("Please enter the Member's CONTACT NUMBER: ");
            ContactNumber = Console.ReadLine();

        }

        public void BorrowDVD()
        {
            if (NumDVDsBorrowed >= 10)
            {
                Console.WriteLine("Sorry, you've already got 10 DVDs borrowed.\n"
                                + "Please return a DVD before borrowing another one.");
                return;
            }
            Console.WriteLine("Please enter the Movie TITLE: ");
            DVDsBorrowed = Console.ReadLine();
            NumDVDsBorrowed++;
        }

        public void ReturnDVD()
        {
            NumDVDsBorrowed--;
        }

        public void ShowCurrentlyBorrowed()
        {

        }

        public void ShowTopTen()
        {

        }



    }
}

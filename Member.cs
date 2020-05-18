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
        public string UserName
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public string ContactNumber
        {
            get; set;
        }
        public string Address
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

        public void RegisterMember()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Member's FIRST NAME: ");
            string firstName = Console.ReadLine();
            FirstName = firstName.ToLower();
            Console.WriteLine("Please enter the Member's LAST NAME: ");
            string lastName = Console.ReadLine().ToLower();
            LastName = lastName.ToLower();

            FullName = FirstName + ' ' + LastName;
            UserName = lastName + firstName;    // Case sensitive

            Console.WriteLine("Please create the user's FOUR DIGIT PASSWORD: ");
            string password = Console.ReadLine();
            if (password.Length != 4)
            {
                while (password.Length != 4)
                {
                    Console.WriteLine("User's password must be FOUR digits long. Please re-enter: ");
                    password = Console.ReadLine();
                }
            }
            bool isPassValid = Int32.TryParse(password, out _);
            if (!isPassValid)
            {
                while (!isPassValid)
                {
                    Console.WriteLine("User's password must contain only digits. Please re-enter: ");
                    password = Console.ReadLine();
                    isPassValid = Int32.TryParse(password, out _);
                }
            }
            Password = password;


            Console.WriteLine("Please enter the Member's CONTACT NUMBER: ");
            string contactNumber = Console.ReadLine();
            bool isContactValid = Int32.TryParse(contactNumber, out _);
            if (!isContactValid)
            {
                while (!isContactValid)
                {
                    Console.WriteLine("User's phone number must contain only digits. Please re-enter: ");
                    contactNumber = Console.ReadLine();
                    isPassValid = Int32.TryParse(password, out _);
                }
            }
            ContactNumber = contactNumber;

            Console.WriteLine("Please enter the Member's ADDRESS: ");
            string address = Console.ReadLine();
            Address = address;

        }

        public void BorrowDVD()
        {
            if (NumDVDsBorrowed >= 10)
            {
                Console.WriteLine("\nSorry, you've already got 10 DVDs borrowed.\n"
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

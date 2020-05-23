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
        public int Index
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

        public void BorrowDVD(string movieTitle)
        {
            if (DVDsBorrowed == "")
            {
                DVDsBorrowed = movieTitle;
            }
            else
            {
                DVDsBorrowed += ("," + movieTitle);
            }
            
            NumDVDsBorrowed++;
        }

        public void ReturnDVD(string movieTitle)
        {
            // Split DVD's Borrowed by ', ' and rejoin without returned movie
            string[] borrowedMovies = DVDsBorrowed.Split(',');
            string revisedMovies = "";
            for (int i = 0; i < borrowedMovies.Length; i++)
            {
                if (borrowedMovies[i] == movieTitle)
                {
                    revisedMovies += "";
                }
                else
                {
                    if (revisedMovies == "")
                    {
                        revisedMovies = borrowedMovies[i];
                    }
                    else
                    {
                        revisedMovies += ("," + borrowedMovies[i]);
                    }
                }
            }
            DVDsBorrowed = revisedMovies;
            NumDVDsBorrowed--;
        }

        public void DisplayBorrowed(MovieCollection movieCollection)
        {
            // Split string by ', ' and retrieve from info from BST movieCollection
            if (DVDsBorrowed != "")
            {
                string[] borrowedMovies = DVDsBorrowed.Split(',');
                movieCollection.DisplayBorrowed(borrowedMovies);
            }
        }

        public void ShowTopTen()
        {

        }



    }
}

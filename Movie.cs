using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_LibraryManagement
{
    class Movie : IComparable<Movie>
    {

        public Movie LeftChild
        {
            get; set;
        }
        public Movie RightChild
        {
            get; set;
        }

        public string Title
        { 
            get; set; 
        }
        public string Starring
        {
            get; set;
        }
        public string Director
        {
            get; set;
        }
        public string Duration
        {
            get; set;
        }
        public string Genre
        {
            get; set;
        }
        public string Classification
        {
            get; set;
        }
        public string ReleaseDate
        {
            get; set;
        }
        public int TimesBorrowed
        {
            get; set;
        }
        public int CopiesAvailable
        {
            get; set;
        }

        public Movie()
        {
            LeftChild = null;
            RightChild = null;
        }

        public int CompareTo(Movie otherMovie)
        {
            return this.Title.CompareTo(otherMovie.Title);
        }
        public int CompareTo(string movieTitle)
        {
            return this.Title.CompareTo(movieTitle);
        }

        public void AddDVD()
        {

            Console.WriteLine("Please enter the Movie's TITLE: ");
            Title = Console.ReadLine();
            Console.WriteLine("Please enter the Movie's STARRING ACTORS: ");
            Starring = Console.ReadLine();
            Console.WriteLine("Please enter the Movie's DIRECTOR: ");
            Director = Console.ReadLine();
            Console.WriteLine("Please enter the Movie's DURATION: ");
            Duration = Console.ReadLine();
            Console.WriteLine("Please enter the Movie's GENRE: ");
            Console.WriteLine("1. Drama\n"
                            + "2. Adventure\n"
                            + "3. Family\n"
                            + "4. Action\n"
                            + "5. Sci-Fi\n"
                            + "6. Comedy\n"
                            + "7. Animated\n"
                            + "8. Thriller\n"
                            + "9. Other");
            string genreNum = Console.ReadLine();
            Genre = ReturnGenre(genreNum);
            Console.WriteLine("Please enter the Movie's CLASSIFICATION: ");
            Console.WriteLine("1. General (G)\n"
                            + "2. Parental Guidance (PG)\n"
                            + "3. Mature (M15+)\n"
                            + "4. Mature Accompanied (MA15+)\n");
            string classificationNum = Console.ReadLine();
            Classification = ReturnClassification(classificationNum);
            Console.WriteLine("Please enter the Movie's RELEASE DATE: ");
            ReleaseDate = Console.ReadLine();
            Console.WriteLine("Please enter the number of copies being added: ");
            string numCopies = Console.ReadLine();
            bool isNumCopiesValid = Int32.TryParse(numCopies, out _);
            if (!isNumCopiesValid)
            {
                while (!isNumCopiesValid)
                {
                    Console.WriteLine("The number of copies must be only digits. Please re-enter: ");
                    numCopies = Console.ReadLine();
                    isNumCopiesValid = Int32.TryParse(numCopies, out _);
                }
            }
            CopiesAvailable = Int32.Parse(numCopies);
        }

        private string ReturnGenre(string genreNum)
        {
            switch(genreNum)
            {
                case "1":
                    return "Drama";
                case "2":
                    return "Adventure";
                case "3":
                    return "Family";
                case "4":
                    return "Action";
                case "5":
                    return "Sci-Fi";
                case "6":
                    return "Comedy";
                case "7":
                    return "Animated";
                case "8":
                    return "Thriller";
                case "9":
                    return "Other";
                default:
                    return "Other";
            }
        }
        private string ReturnClassification(string classificationNum)
        {
            switch (classificationNum)
            {
                case "1":
                    return "General (G)";
                case "2":
                    return "Parental Guidance (PG)";
                case "3":
                    return "Mature (M15+)";
                case "4":
                    return "Mature Accompanied (MA15+)";
                default:
                    return "General (G)";
            }
        }

        public void DisplayMovie()
        {
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Starring: {0}", Starring);
            Console.WriteLine("Director: {0}", Director);
            Console.WriteLine("Duration: {0}", Duration);
            Console.WriteLine("Genre: {0}", Genre);
            Console.WriteLine("Classification: {0}", Classification);
            Console.WriteLine("Release Date: {0}", ReleaseDate);
            Console.WriteLine("Times Borrowed: {0}", TimesBorrowed);
            Console.WriteLine("Copies Available: {0}", CopiesAvailable);
            Console.WriteLine();
        }


        public void Borrow()
        {
            TimesBorrowed++;
            CopiesAvailable--;
        }
        public void Return()
        {
            CopiesAvailable++;
        }

    }
}

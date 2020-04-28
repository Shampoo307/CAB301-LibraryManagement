using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_LibraryManagement
{
    class Movie
    {
        public string Title
        { get; set; }
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
            Genre = Console.ReadLine();
            Console.WriteLine("Please enter the Movie's CLASSIFICATION: ");
            Console.WriteLine("1. General (G)\n"
                            + "2. Parental Guidance (PG)\n"
                            + "3. Mature (M15+)\n"
                            + "4. Mature Accompanied (MA15+)\n");
            Classification = Console.ReadLine();
            Console.WriteLine("Please enter the Movie's RELEASE DATE: ");
            ReleaseDate = Console.ReadLine();
            
        }

    }
}

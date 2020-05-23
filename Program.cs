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

            PopulateMembersAndMovies(memberCollection, movieCollection);

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
                }
                else
                {
                    Console.WriteLine("Incorrect login, press any key to return to menu...");
                    Console.ReadLine();
                    MainMenu(memberCollection, movieCollection);
                }
            }
            else if (response == "2")
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

            }
            else if (response == "0")
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
            return memberIndex;
        }


        public static void PopulateMembersAndMovies(MemberCollection memberCollection, MovieCollection movieCollection)
        {
            PopulateMembers(memberCollection);
            PopulateMovies(movieCollection);
        }

        public static void PopulateMembers(MemberCollection memberCollection)
        {
            Member member = new Member();
            member.FirstName = "Anthony"; member.LastName = "Warden";
            member.FullName = "Anthony Warden"; member.UserName = "WardenAnthony";
            member.Password = "2020"; member.ContactNumber = "0400123";
            member.Address = "5 Flint Street";
            memberCollection.AddMember(member);
            Member member1 = new Member();
            member1.FirstName = "Jemma"; member1.LastName = "Cross";
            member1.FullName = "Jemma Cross"; member1.UserName = "CrossJemma";
            member1.Password = "1995"; member1.ContactNumber = "0475982";
            member1.Address = "8 Crescent Court";
            memberCollection.AddMember(member1);
            Member member2 = new Member();
            member2.FirstName = "Mark"; member2.LastName = "Greenslope";
            member2.FullName = "Mark Greenslope"; member2.UserName = "GreenslopeMark";
            member2.Password = "4053"; member2.ContactNumber = "0469287";
            member2.Address = "12 Adelaide Circuit";
            memberCollection.AddMember(member2);
        }
        public static void PopulateMovies(MovieCollection movieCollection)
        {
            Movie movie = new Movie();
            movie.Title = "Inception"; movie.Starring = "Leonardo DiCaprio";
            movie.Director = "Christopher Nolan"; movie.Duration = "2 Hours 28 Minutes";
            movie.Genre = "Thriller"; movie.Classification = "Parental Guidance (PG)";
            movie.ReleaseDate = "2010"; movie.TimesBorrowed = 8; movie.CopiesAvailable = 3;
            movieCollection.Insert(movie);
            Movie movie1 = new Movie();
            movie1.Title = "Midnight Express"; movie1.Starring = "Brad Davis";
            movie1.Director = "Alan Parker"; movie1.Duration = "2 Hours 1 Minutes";
            movie1.Genre = "Drama"; movie1.Classification = "Mature Accompanied (MA15+)";
            movie1.ReleaseDate = "1978"; movie1.TimesBorrowed = 4; movie1.CopiesAvailable = 1;
            movieCollection.Insert(movie1);
            Movie movie2 = new Movie();
            movie2.Title = "The Incredibles"; movie2.Starring = "Craig T. Nelson";
            movie2.Director = "Christopher Nolan"; movie2.Duration = "1 Hours 56 Minutes";
            movie2.Genre = "Family"; movie2.Classification = "Parental Guidance (PG)";
            movie2.ReleaseDate = "2004"; movie2.TimesBorrowed = 10; movie2.CopiesAvailable = 3;
            movieCollection.Insert(movie2);
            Movie movie3 = new Movie();
            movie3.Title = "Pulp Fiction"; movie3.Starring = "Samuel L. Jackson";
            movie3.Director = "Quentin Tarantino"; movie3.Duration = "2 Hours 58 Minutes";
            movie3.Genre = "Comedy"; movie3.Classification = "Mature Accompanied (MA15+)";
            movie3.ReleaseDate = "1994"; movie3.TimesBorrowed = 6; movie3.CopiesAvailable = 2;
            movieCollection.Insert(movie3);
            Movie movie4 = new Movie();
            movie4.Title = "Blade Runner"; movie4.Starring = "Harrison Ford";
            movie4.Director = "Ridley Scott"; movie4.Duration = "1 Hours 57 Minutes";
            movie4.Genre = "Sci-Fi"; movie4.Classification = "Mature Accompanied (MA15+)";
            movie4.ReleaseDate = "1982"; movie4.TimesBorrowed = 3; movie4.CopiesAvailable = 1;
            movieCollection.Insert(movie4);
            Movie movie5 = new Movie();
            movie5.Title = "The Platform"; movie5.Starring = "Ivan Massague";
            movie5.Director = "Galder Gaztelu-Urrutia"; movie5.Duration = "1 Hours 34 Minutes";
            movie5.Genre = "Sci-Fi"; movie5.Classification = "Mature Accompanied (MA15+)";
            movie5.ReleaseDate = "2019"; movie5.TimesBorrowed = 1; movie5.CopiesAvailable = 1;
            movieCollection.Insert(movie5);
            Movie movie6 = new Movie();
            movie6.Title = "Nightcrawler"; movie6.Starring = "Jake Gyllenhaal";
            movie6.Director = "Dan Gilroy"; movie6.Duration = "1 Hours 57 Minutes";
            movie6.Genre = "Thriller"; movie6.Classification = "Mature Accompanied (MA15+)";
            movie6.ReleaseDate = "2014"; movie6.TimesBorrowed = 5; movie6.CopiesAvailable = 1;
            movieCollection.Insert(movie6);
            Movie movie7 = new Movie();
            movie7.Title = "The Godfather"; movie7.Starring = "Marlon Brando";
            movie7.Director = "Francis Ford Coppola"; movie7.Duration = "2 Hours 58 Minutes";
            movie7.Genre = "Drama"; movie7.Classification = "Mature Accompanied (MA15+)";
            movie7.ReleaseDate = "1972"; movie7.TimesBorrowed = 7; movie7.CopiesAvailable = 2;
            movieCollection.Insert(movie7);
            Movie movie8 = new Movie();
            movie8.Title = "The Two Popes"; movie8.Starring = "Anthony Hopkins";
            movie8.Director = "Fernando Meirelles"; movie8.Duration = "2 Hours 6 Minutes";
            movie8.Genre = "Drama"; movie8.Classification = "Parental Guidance (PG)";
            movie8.ReleaseDate = "2019"; movie.TimesBorrowed = 1; movie8.CopiesAvailable = 1;
            movieCollection.Insert(movie8);
            Movie movie9 = new Movie();
            movie9.Title = "Uncut Gems"; movie9.Starring = "Adam Sandler";
            movie9.Director = "Josh Safdie"; movie9.Duration = "2 Hours 15 Minutes";
            movie9.Genre = "Comedy"; movie9.Classification = "Mature Accompanied (MA15+)";
            movie9.ReleaseDate = "2019"; movie9.TimesBorrowed = 3; movie9.CopiesAvailable = 1;
            movieCollection.Insert(movie9);
            Movie movie10 = new Movie();
            movie10.Title = "My Neighbour Totoro"; movie10.Starring = "Noriko Hidaka";
            movie10.Director = "Hayao Miyazaki"; movie10.Duration = "1 Hours 28 Minutes";
            movie10.Genre = "Animated"; movie10.Classification = "General (G)";
            movie10.ReleaseDate = "1988"; movie10.TimesBorrowed = 12; movie10.CopiesAvailable = 4;
            movieCollection.Insert(movie10);
        }

    }
}

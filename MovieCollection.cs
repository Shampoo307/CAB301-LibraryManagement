using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_LibraryManagement
{
    // BINARY SEARCH TREE TO STORE INFO
    class MovieCollection
    {

        //Movie[] movies = new Movie[50];
        Movie root;

        public MovieCollection()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public Movie Search(string movieTitle)
        {
            return Search(movieTitle, root);
        }

        private Movie Search(string movieTitle, Movie root)
        {
            if (root != null)
            {
                if (root.CompareTo(movieTitle) == 0)
                {
                    return root;
                }
                else if (root.CompareTo(movieTitle) > 0)
                {
                    return Search(movieTitle, root.LeftChild);
                }
                else
                {
                    return Search(movieTitle, root.RightChild);
                }
            }
            else
            {
                return null;
            }
        }

        public bool BoolSearch(string movieTitle)
        {
            return BoolSearch(movieTitle, root);
        }

        private bool BoolSearch(string movieTitle, Movie root)
        {
            if (root != null)
            {
                if (root.CompareTo(movieTitle) == 0)
                {
                    return true;
                }
                else if (root.CompareTo(movieTitle) > 0)
                {
                    return BoolSearch(movieTitle, root.LeftChild);
                }
                else
                {
                    return BoolSearch(movieTitle, root.RightChild);
                }
            }
            else
            {
                return false;
            }
        }

        public void Insert(Movie movie)
        {
            if (root == null)
            {
                root = movie;
            }
            else
            {
                Insert(movie, root);
            }
        }

        private void Insert(Movie movie, Movie ptr)
        {
            if (movie.CompareTo(ptr) < 0)
            {
                if (ptr.LeftChild == null)
                {
                    ptr.LeftChild = movie;

                }
                else
                {
                    Insert(movie, ptr.LeftChild);
                }
            }
            else
            {
                if (ptr.RightChild == null)
                {
                    ptr.RightChild = movie;
                }
                else
                {
                    Insert(movie, ptr.RightChild);
                }
            }
        }

        public void Delete(Movie movie)
        {
            // Search for item and parent
            Movie ptr = root; // Search reference
            Movie parent = null; // parent of ptr
            while ((ptr != null) && (movie.CompareTo(ptr) != 0))
            {
                parent = ptr;
                if (movie.CompareTo(ptr) < 0) // Move to left child of ptr
                {
                    ptr = ptr.LeftChild;
                }
                else
                {
                    ptr = ptr.RightChild;
                }
            }

            if (ptr != null)
            {
                // If movie node has two children
                if ((ptr.LeftChild != null) && (ptr.RightChild != null))
                {
                    // Find right-most node in left subtree
                    if (ptr.LeftChild.RightChild == null) // If right subtree of ptr.LeftChild is empty
                    {   // Copy all data across, before also copying over left child
                        ptr.Title = ptr.LeftChild.Title;
                        ptr.Starring = ptr.LeftChild.Title;
                        ptr.Director = ptr.LeftChild.Director;
                        ptr.Duration = ptr.LeftChild.Duration;
                        ptr.Genre = ptr.LeftChild.Genre;
                        ptr.Classification = ptr.LeftChild.Classification;
                        ptr.ReleaseDate = ptr.LeftChild.ReleaseDate;
                        ptr.TimesBorrowed = ptr.LeftChild.TimesBorrowed;
                        ptr.LeftChild = ptr.LeftChild.LeftChild;
                    }
                    else
                    {
                        Movie movieTemp = ptr.LeftChild;
                        Movie movieTempParent = ptr;
                        while (movieTemp.RightChild != null)
                        {
                            movieTempParent = movieTemp;
                            movieTemp = movieTemp.RightChild;
                        }
                        // Copy movieTemp to ptr
                        ptr.Title = movieTemp.Title;
                        ptr.Starring = movieTemp.Title;
                        ptr.Director = movieTemp.Director;
                        ptr.Duration = movieTemp.Duration;
                        ptr.Genre = movieTemp.Genre;
                        ptr.Classification = movieTemp.Classification;
                        ptr.ReleaseDate = movieTemp.ReleaseDate;
                        ptr.TimesBorrowed = movieTemp.TimesBorrowed;
                        movieTempParent.RightChild = movieTemp.LeftChild;
                    }
                }
                else    // Movie node has zero or one child
                {
                    Movie child;
                    if (ptr.LeftChild != null)
                    {
                        child = ptr.LeftChild;
                    }
                    else
                    {
                        child = ptr.RightChild;
                    }

                    // Remove node ptr
                    if (ptr == root)    // Change root
                    {
                        root = child;
                    }
                    else
                    {
                        if (ptr == parent.LeftChild)
                        {
                            parent.LeftChild = child;
                        }
                        else
                        {
                            parent.RightChild = child;
                        }
                    }
                }
            }
        }

        public void AddDVD(Movie movie)
        {
            // BST Insert
            Insert(movie);
        }

        public void RemoveDVD(string movie)
        {
            Delete(Search(movie));
        }

        public bool MovieExists(string movieTitle)
        {
            return BoolSearch(movieTitle);
        }

        public void DisplayAll()    // In order traverse
        {
            // BST search; if != null -> list[]
            Console.WriteLine("Movies held in this library: \n");
            DisplayAll(root);
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }

        private void DisplayAll(Movie root)
        {
            if (root != null)
            {
                DisplayAll(root.LeftChild);
                root.DisplayMovie();
                DisplayAll(root.RightChild);
            }
        }

        public void BorrowDVD(string movieTitle)
        {
            if (Search(movieTitle).CopiesAvailable <= 0)
            {
                Console.WriteLine("There are no more copies of {0} available.");
            }
            else
            {
                Search(movieTitle).Borrow();
            }
        }

        public void ReturnDVD(string movieTitle)
        {
            Search(movieTitle).Return();
        }

        public void DisplayBorrowed(string[] borrowed)
        {
            for (int i = 0; i < borrowed.Length; i++)
            {
                Movie movie = Search(borrowed[i]);
                if (movie != null)
                {
                    Console.WriteLine("Title: {0}", movie.Title);
                    Console.WriteLine("Starring: {0}", movie.Starring);
                    Console.WriteLine("Director: {0}", movie.Director);
                    Console.WriteLine("Duration: {0}", movie.Duration);
                    Console.WriteLine("Genre: {0}", movie.Genre);
                    Console.WriteLine("Classification: {0}", movie.Classification);
                    Console.WriteLine("Release Date: {0}", movie.ReleaseDate);
                    Console.WriteLine("Times Borrowed: {0}\n", movie.TimesBorrowed);
                }
                
            }
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }




    }
}

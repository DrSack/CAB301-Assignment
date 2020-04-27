using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{
    class MovieHistory
    {
        public Movie Movie;
        private int count { get; set; }
        public MovieHistory(Movie movie)
        {
            this.Movie = movie;
            count = 0;
        }

        public string GetTitle()
        {
            return Movie.Title;
        }

        public void SetCount()
        {
            count++;
        }

        public void FinalCount(int num)
        {
            count = num;
        }

        public int GetCount()
        {
            return count;
        }

    }
    class MovieArchive
    {
        List<MovieHistory> MoviesHist;
        public MovieArchive()
        {
            MoviesHist = new List<MovieHistory>();
        }

        public void AddMovie(Movie movie)
        {
            bool truth = true;
            //Check if movie currently exists.
            for(int i = 0; i < MoviesHist.Count; i++)
            {
                if(MoviesHist[i].GetTitle() == movie.Title)
                {
                    truth = false;
                    break;
                }
            }
            if (truth)
            {
                MoviesHist.Add(new MovieHistory(movie));
            }
        }

        public void RemoveMovie(string movie)
        {
            //Check if movie currently exists.
            for (int i = 0; i < MoviesHist.Count; i++)
            {
                if (MoviesHist[i].GetTitle() == movie)
                {
                    MoviesHist.RemoveAt(i);
                }
            }
        }

        public void AddView(string movie)
        {
            //Check if movie currently exists.
            for (int i = 0; i < MoviesHist.Count; i++)
            {
                if (MoviesHist[i].GetTitle() == movie)
                {
                    MoviesHist[i].SetCount();
                }
            }
        }

        /*
        Parameters: NONE 
             
        Display the most popluar borrowed movies within the MovieCollection
        
        Returns: NONE
        */
        public void Display()
        {
            MovieHistory temp;// Decalre empty object
            for (int i = 0; i < MoviesHist.Count-1; i++)//iterate n
            {
                for(int j = i + 1; j < MoviesHist.Count; j++)// iterate n^2
                {
                    if(MoviesHist[i].GetCount() < MoviesHist[j].GetCount())// if the count of views is less then the next elements views
                    {
                    temp = new MovieHistory(new Movie(MoviesHist[i].Movie.Title, MoviesHist[i].Movie.Starring, MoviesHist[i].Movie.Director, MoviesHist[i].Movie.Duration, MoviesHist[i].Movie.Genre, MoviesHist[i].Movie.Classification, MoviesHist[i].Movie.ReleaseDate));
                    temp.FinalCount(MoviesHist[i].GetCount());
                    MoviesHist[i] = MoviesHist[j];
                    MoviesHist[j] = temp;
                    }// Change spots.
                }
            }
            Console.WriteLine("==============Most Popular Movies==============");
            if (MoviesHist.Count < 10)// IF less than 10 then display all of the movies
            {
                for (int i = 0; i < MoviesHist.Count; i++)
                {
                    
                    Console.WriteLine("");
                    Console.WriteLine((i + 1).ToString()+". ");
                    Console.WriteLine(String.Format("Title: {0}",MoviesHist[i].Movie.Title));
                    Console.WriteLine(String.Format("Borrowed: {0}",MoviesHist[i].GetCount().ToString()));
                } 
            }
            else
            {// ELSE then display up to 10 only.
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("");
                    Console.WriteLine((i + 1).ToString() + ". ");
                    Console.WriteLine(String.Format("Title: {0}", MoviesHist[i].Movie.Title));
                    Console.WriteLine(String.Format("Borrowed: {0}", MoviesHist[i].GetCount().ToString()));
                }
            }
            Console.WriteLine("");
            Console.WriteLine("===============================================");
        }
    }
}

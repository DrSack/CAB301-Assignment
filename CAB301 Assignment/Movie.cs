using System;

namespace CAB301_Assignment
{
    //This is the Movie class which creates movie objects to be used withint he MovieCollection BST.
    public class Movie
    {
        public string Title { get; set; } //Declare all variables
        public string Starring { get; set; }
        public string Director { get; set; }
        public float Duration { get; set; }
        public string Genre { get; set; }
        public string Classification { get; set; }
        public string ReleaseDate { get; set; }
        public int View { get; set; }

        /*
        parameter: title, starring, director, duration, genre, classification, releasedate

        This is the Movie constructor and this adds all of paramters and arguments into the declared variables, this also sets the variable View to 0; 

        returns: nothing
        */

        public Movie(string title, string starring, string director, float duration ,string genre, string classification, string releasedate)
        {
            this.Title = title;
            this.Starring = starring;
            this.Director = director;
            this.Duration = duration;
            this.Genre = genre;
            this.Classification = classification;
            this.ReleaseDate = releasedate;
            View = 0;
        }
    }


    

}

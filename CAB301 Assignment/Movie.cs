using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{
    public class Movie
    {
        public string Title { get; set; }
        public string Starring { get; set; }
        public string Director { get; set; }
        public float Duration { get; set; }
        public string Genre { get; set; }
        public string Classification { get; set; }
        public string ReleaseDate { get; set; }
        public Movie(string title, string starring, string director, float duration ,string genre, string classification, string releasedate)
        {
            this.Title = title;
            this.Starring = starring;
            this.Director = director;
            this.Duration = duration;
            this.Genre = genre;
            this.Classification = classification;
            this.ReleaseDate = releasedate;
        }
    }


    

}

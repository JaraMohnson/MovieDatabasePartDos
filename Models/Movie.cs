using System;
using System.Collections.Generic;
using EFMovies;
using EFMovies.Models;

namespace EFMovies.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public double? Runtime { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-25} {1,-10} {2,-55}", $"{Title}", $"{Genre}", $"{Runtime} minutes");
            
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ILikeToEatOut { get; set; }
        public string ILikeToWatchMovies { get; set; }
        public string ILikeToWatchTV { get; set; }
        public string iLikeToListenToTheRadio { get; set; }
        public int PersonId { get; set; }
    }
}
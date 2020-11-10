using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Pizza { get; set; }
        public string Pasta { get; set; }
        public string Papandwors { get; set; }
        public string ChickenstirFry { get; set; }
        public int BeefstirFry { get; set; }
        public string Other { get; set; }
        public int PersonId { get; set; }
    }
}
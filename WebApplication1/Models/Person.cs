﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Surname { get; set; }
        public string FirstNames { get; set; }
        public int ContactNumber { get; set; }
        public string DateOfTakingSurvey { get; set; }
        public float Age { get; set; }
    }
}
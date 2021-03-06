﻿using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;

namespace Store
{
    class State
    {
        //Gör så man kan kalla på tables
        public static Customer User { get; set; }
        public static Customer Password { get; set; }
        public static List<Movie> Movies { get; set; }
        public static Movie Pick { get; set; }
        public static Genre Genre { get; set; }
        public static List<Rental> Rental { get; set; }
    }
}

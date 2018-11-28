﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}

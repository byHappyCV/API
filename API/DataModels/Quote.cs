using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Quote
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }

    }
}

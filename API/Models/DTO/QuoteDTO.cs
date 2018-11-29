using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class QuoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
    }
}

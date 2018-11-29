using System.Collections.Generic;
using Models.DTO;

namespace BAL.Interfaces
{
    public interface IQuoteService
    {
        void AddAuthor(QuoteDTO quote);
        void EditAuthor(QuoteDTO quote);
        void DeleteAuthor(QuoteDTO quote);
        List<QuoteDTO> GetAuthors();
        QuoteDTO GetAuthor(int quoteId);
    }
}
using System.Collections.Generic;
using Models.DTO;

namespace BAL.Interfaces
{
    public interface IQuoteService
    {
        void AddQuote(QuoteDTO quote);
        void EditQuote(QuoteDTO quote);
        void DeleteQuote(QuoteDTO quote);
        List<QuoteDTO> GetQuotes();
        QuoteDTO GetQuote(int quoteId);
    }
}
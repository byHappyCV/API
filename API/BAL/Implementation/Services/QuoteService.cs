using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BAL.Interfaces;
using DataModels;
using DAL.Interfaces;
using Models.DTO;

namespace BAL.Implementation.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuoteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddQuote(QuoteDTO quote)
        {
            _unitOfWork.Quotes.Insert(_mapper.Map<Quote>(quote));
            _unitOfWork.Save();
        }

        public void EditQuote(QuoteDTO quote)
        {
            _unitOfWork.Quotes.Update(_mapper.Map<Quote>(quote));
            _unitOfWork.Save();
        }

        public void DeleteQuote(QuoteDTO quote)
        {
            _unitOfWork.Quotes.Delete(_mapper.Map<Quote>(quote));
            _unitOfWork.Save();
        }
        public List<QuoteDTO> GetQuotes()
        {
            var result = _unitOfWork.Quotes.GetAll();

            return _mapper.Map<List<QuoteDTO>>(result);
        }

        public QuoteDTO GetQuote(int quoteId)
        {
            var result = _unitOfWork.Quotes.Get(c => c.Id == quoteId);

            return _mapper.Map<QuoteDTO>(result);
        }
    }
}

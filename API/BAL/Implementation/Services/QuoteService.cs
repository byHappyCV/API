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

        public void AddAuthor(QuoteDTO quote)
        {
            _unitOfWork.Quotes.Insert(_mapper.Map<Quote>(quote));
            _unitOfWork.Save();
        }

        public void EditAuthor(QuoteDTO quote)
        {
            _unitOfWork.Quotes.Update(_mapper.Map<Quote>(quote));
            _unitOfWork.Save();
        }

        public void DeleteAuthor(QuoteDTO quote)
        {
            _unitOfWork.Quotes.Delete(_mapper.Map<Quote>(quote));
            _unitOfWork.Save();
        }
        public List<QuoteDTO> GetAuthors()
        {
            var result = _unitOfWork.Quotes.GetAll();

            return _mapper.Map<List<QuoteDTO>>(result);
        }

        public QuoteDTO GetAuthor(int quoteId)
        {
            var result = _unitOfWork.Quotes.Get(c => c.Id == quoteId);

            return _mapper.Map<QuoteDTO>(result);
        }
    }
}

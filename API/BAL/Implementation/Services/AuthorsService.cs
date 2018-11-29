using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BAL.Interfaces;
using DataModels;
using DAL.Interfaces;
using Models.DTO;

namespace BAL.Implementation.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddAuthor(AuthorDTO author)
        {
            _unitOfWork.Authors.Insert(_mapper.Map<Author>(author));
            _unitOfWork.Save();
        }

        public void EditAuthor(AuthorDTO author)
        {
            var entity = _mapper.Map<Author>(author);


            _unitOfWork.Authors.Update(entity);
            _unitOfWork.Save();
        }

        public void DeleteAuthor(AuthorDTO author)
        {
            _unitOfWork.Authors.Delete(_mapper.Map<Author>(author));
            _unitOfWork.Save();
        }
        public List<AuthorDTO> GetAuthors()
        {
            var result = _unitOfWork.Authors.GetAll();

            return _mapper.Map<List<AuthorDTO>>(result);
        }

        public AuthorDTO GetAuthor(int authorId)
        {
            var result = _unitOfWork.Authors.Get(c => c.Id == authorId).FirstOrDefault();

            return _mapper.Map<AuthorDTO>(result);
        }
    }
}

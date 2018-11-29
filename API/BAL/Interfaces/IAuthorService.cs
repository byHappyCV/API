using System.Collections.Generic;
using Models.DTO;

namespace BAL.Interfaces
{
    public interface IAuthorsService
    {
        void AddAuthor(AuthorDTO author);
        void EditAuthor(AuthorDTO author);
        void DeleteAuthor(AuthorDTO author);
        List<AuthorDTO> GetAuthors();
        AuthorDTO GetAuthor(int authorId);
    }
}
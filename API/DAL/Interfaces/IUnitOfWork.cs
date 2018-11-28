using System;
using System.Collections.Generic;
using System.Text;
using DataModels;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Author> Authors { get; }
        IRepository<Quote> Quotes { get; }

        int Save();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DataModels;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IRepository<Author> _authors;
        private IRepository<Quote> _quotes;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepository<Author> Authors
        {
            get
            {
                if (_authors == null) { _authors = new Repository<Author>(_context); }
                return _authors;
            }
        }

        public IRepository<Quote> Quotes
        {
            get
            {
                if (_quotes == null) { _quotes = new Repository<Quote>(_context); }
                return _quotes;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool isDisposed = false;

        protected virtual void Grind(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            isDisposed = true;
        }

        public void Dispose()
        {
            Grind(true);
            GC.SuppressFinalize(this);
        }

    }
}

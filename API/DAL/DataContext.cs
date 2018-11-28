using System;
using System.Collections.Generic;
using System.Text;
using DataModels;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}

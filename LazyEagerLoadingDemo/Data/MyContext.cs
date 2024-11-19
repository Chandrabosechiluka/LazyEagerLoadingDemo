using LazyEagerLoadingDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LazyEagerLoadingDemo.Data
{
    public class MyContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
    }
}

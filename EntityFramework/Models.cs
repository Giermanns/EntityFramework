using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;

namespace ConsoleApp.NewDb
{
    public class BloggingContext : DbContext
    {
        private object options;

        public BloggingContext()
        {
        }

        public BloggingContext(object options)
        {
            this.options = options;
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Server
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
                optionsBuilder.ConfigureWarnings(warnigs => warnigs.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
        }
    }
}
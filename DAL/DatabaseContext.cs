using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=ADITYARAJ; initial catalog=EFCoreMigrationDB; persist security info=true; user id=sa;password=sql@2017;"); 
        }
    }
}

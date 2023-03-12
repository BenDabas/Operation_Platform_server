using Microsoft.EntityFrameworkCore;
using Operation_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Operation_Platform.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>().HasData(
                new Operation { Id = 1, FirstField = "1", SecondField = "1", Operator = "+", DateTime = DateTime.Now });
        }
    }
}

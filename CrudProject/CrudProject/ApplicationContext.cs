using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProject.Models;
namespace CrudProject
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserDto> UserDto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
             {
              optionsBuilder.UseSqlServer(@"Server=LAPTOP-8A2JNQVG\SQLEXPRESS;Database=MYDB;Trusted_Connection=True;");
           }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab2_1_Course
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = Program.config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            
            optionsBuilder.LogTo(s => Debug.WriteLine(s));

        }
    }
}

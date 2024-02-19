using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab2_0_EntityFrame
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = Program.config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-CBUNM8I;Database=persondb;User Id=test;Password=test;TrustServerCertificate=True;");
            //optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.LogTo(s => Debug.WriteLine(s));

        }
    }
}

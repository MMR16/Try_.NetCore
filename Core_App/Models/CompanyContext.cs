using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_App.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions options) :base(options)
        {

        }


        //Destop
        //connection string
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=CoreApp;Integrated Security=true");
        //    optionsBuilder.UseSqlServer("Server=.; Database=CoreApp;Trusted_Connection=true");
        //}

        public virtual  DbSet<Employee> Employees { get; set; }
        public virtual  DbSet<Department> Departments { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Curd_Login.Models
{
    public class DbServiceContext : DbContext
    {
        public DbSet<Employee> tbl_emp {  get; set; }

    }
}
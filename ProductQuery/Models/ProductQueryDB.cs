using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductQuery.Models
{
    public class ProductQueryDB:DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
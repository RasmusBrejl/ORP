using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORP.Model
{
    public class OrpContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Clearance> Clearances { get; set; }
    }
}
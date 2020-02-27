using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ORP.Models;

namespace ORP.Model
{
    public class OrpContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Clearance> Clearances { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Connection> Connections { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Parcel> Parcels { get; set; }

        public DbSet<ParcelCategory> ParcelCategories { get; set; }


    }
}
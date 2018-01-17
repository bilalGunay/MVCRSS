using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RSSKO.Models
{
    public class RssContext : DbContext
    {
        public RssContext() : base("RssContextDB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<User> Userlar { get; set; }
        public virtual DbSet<Sonuclar> Sonuclar { get; set; }
        public virtual DbSet<Sorular> Sorular { get; set; }
        public virtual DbSet<RssHeader> RssHeaderlar { get; set; }
    }
}
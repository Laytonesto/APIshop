using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using APIshop.Models.Procedures;

namespace APIshop.Models
{
    public class EFShop : DbContext
    {
        public DbSet<get_productos> producto { get; set; }

        public EFShop()
            : base("name=EFShop")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
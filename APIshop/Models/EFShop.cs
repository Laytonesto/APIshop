using System;
using System.Data.Entity;
using System.Linq;
using APIshop.Models.Procedures;

namespace APIshop.Models
{
    public class EFShop : DbContext
    {
        public EFShop()
            : base("name=EFShop")
        {
        }
    }
}
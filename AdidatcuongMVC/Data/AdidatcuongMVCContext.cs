using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdidatcuongMVC.Models;

namespace AdidatcuongMVC.Data
{
    public class AdidatcuongMVCContext : DbContext
    {
        public AdidatcuongMVCContext (DbContextOptions<AdidatcuongMVCContext> options)
            : base(options)
        {
        }

        public DbSet<AdidatcuongMVC.Models.Agent> Agent { get; set; }

        public DbSet<AdidatcuongMVC.Models.Orders> Orders { get; set; }

        public DbSet<AdidatcuongMVC.Models.Order_Detail> Order_Detail { get; set; }

        public DbSet<AdidatcuongMVC.Models.Product> Product { get; set; }

        public DbSet<AdidatcuongMVC.Models.PImage> PImage { get; set; }
    }
}

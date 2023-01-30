using Fake_Store_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Fake_Store_Data.DataSet
{
    public class DbSet :IdentityDbContext<IdentityUser>
    {
        public DbSet(DbContextOptions<DbSet> options) : base(options)
        {

        }
    

      


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().OwnsOne(x => x.rating);
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DbSet).Assembly);

        }
    }
}

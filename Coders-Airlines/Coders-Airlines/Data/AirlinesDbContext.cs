using Coders_Airlines.Auth.Model;
using Coders_Airlines.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Data
{
    public class AirlinesDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public AirlinesDbContext(DbContextOptions options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Category>().HasData
            //   (

            //    );

            SeedRoles(modelBuilder, "administrator", "create", "delete");
            SeedRoles(modelBuilder, "user", "create");
        }

        private int id = 1;
        private void SeedRoles(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()

            };
            modelBuilder.Entity<IdentityRole>().HasData(role);

            var RoleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = id++,
                RoleId = role.Id,
                ClaimType = "permissions",
                ClaimValue = permission
            }
            ).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(RoleClaims);
        }
    }
}

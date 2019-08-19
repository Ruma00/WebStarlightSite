using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarlightProject_Site.Models;
using StarlightProject_Site.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StarlightProject_Site.Controllers;

namespace StarlightProject_Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<StoryModel> Stories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //string adminEmail = "admin@mail.ru";
            //string adminPassword = "_Aa123456";

            //IdentityUser user = new IdentityUser { UserName = adminEmail, Email = adminEmail };
            //userManager.CreateAsync(user, adminPassword);
            //userManager.CreateAsync(user, adminPassword);
            //IPasswordHasher<IdentityUser> hasher = userManager.PasswordHasher;

            //this.Users.Add(user);

            //user.PasswordHash = hasher.HashPassword(user, adminPassword);

            //builder.Entity<IdentityUser>().HasData(new IdentityUser[] { user });

            base.OnModelCreating(builder);
        }
    }
}

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Domain.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public double Credit { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

   
        public class Baza : IdentityDbContext<ApplicationUser>
        {
            public Baza()
                : base("EasyBike", throwIfV1Schema: false)
        { }
        public DbSet<File> File { get; set; }
        public DbSet<FileType> FileType { get; set; }
        public DbSet<Bike> Bike { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Sex> Sex { get; set; }




        public static Baza Create()
            {
                return new Baza();
            }
        }
    }

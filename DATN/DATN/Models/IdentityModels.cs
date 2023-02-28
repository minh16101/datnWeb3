using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using DATN.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DATN.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<InformationUser> InformationUser { get; set; }
        public DbSet<BookingHotel> BookingHotel { get; set; }
        public DbSet<BookingRoom> BookingRoom { get; set; }
        public DbSet<ImageHotel> ImageHotel { get; set; }
        public DbSet<ImageRoom> ImageRoom { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
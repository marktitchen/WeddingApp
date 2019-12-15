//using System.Data.Entity;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

//namespace WeddingApp.Models
//{
//    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
//    public class ApplicationUser : IdentityUser
//    {
//        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
//        {
//            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
//            // Add custom user claims here
//            return userIdentity;
//        }
//    }

//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public DbSet<Event> Events { get; set; }
//        public DbSet<WeddingPackage> WeddingPackages { get; set; }
        
//        public ApplicationDbContext()
//            : base("DefaultConnection", throwIfV1Schema: false)
//        {
//        }

//        public static ApplicationDbContext Create()
//        {
//            return new ApplicationDbContext();
//        }
//    }
//}

//////////////////////////////////////////////////
/////

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WeddingApp.Models
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
       
        
        public DbSet<WeddingPackage> WeddingPackages { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<EnquiryCategory> EnquiryCategories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyME.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
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
        public DbSet<SurveyForms> SurveyForms_Dbset { get; set; }
        public DbSet<Professions> Professions_Dbset { get; set; }
        public DbSet<ResearchAreas> ResearchArea_Dbset { get; set; }
        public DbSet<Profile> Profile_Dbset { get; set; }
        public DbSet<BookmarkedSurveyForms> BookmarkedSurveyForms_Dbset { get; set; }
        public  DbSet<EmployerDetails> EmployerDetails_Dbset { get; set; }
        public  DbSet<MinistryDetails> MinistryDetails_Dbset { get; set; }
        public DbSet<SurveyQuestionType> SurveyQuestionTypes_Dbset { get; set; }
        public DbSet<BinaryChoice> BinaryChoices_Dbset { get; set; }
        public DbSet<Sections> Sections_Dbset { get; set; }

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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.ASP.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "091f13e5-cdd4-4fd9-8a90-2ba03dd246f1";
            var writerRoleId = "ff61b55f-8083-413c-86b8-3a3f57c2258b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                     Id= readerRoleId,
                     ConcurrencyStamp= readerRoleId,
                     Name="Reader",
                     NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                     Id= writerRoleId,
                     ConcurrencyStamp= writerRoleId,
                     Name="Writer",
                     NormalizedName="Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

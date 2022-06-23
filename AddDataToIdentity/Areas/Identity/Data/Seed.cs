using AddDataToIdentity.Data;
using Microsoft.EntityFrameworkCore;

namespace AddDataToIdentity.Areas.Identity.Data
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AddDataToIdentityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AddDataToIdentityContext>>());
            if (context == null || context.Phone == null)
            {
                throw new ArgumentNullException();// paramName:"Null AddDataToIdentityContext or Phone");
            }

            // Look for any movies.
            if (context.Phone.Any())
            {
                return;   // DB has been seeded
            }

            context.Phone.AddRange(
                new Phone
                {
                    Name = "AName",
                    PhoneNumber = "8(918)1234567",
                    Description = "Any",
                    Money = 5.98M
                },

                new Phone
                {
                    Name = "BName",
                    PhoneNumber = "8(918)1234560",
                    Description = "Any2",
                    Money = 3.08M
                },

                new Phone
                {
                    Name = "CName",
                    PhoneNumber = "8(918)0123456",
                    Description = "Any2",
                    Money = 15.55M
                }

            );
            context.SaveChanges();
        }
    }
}

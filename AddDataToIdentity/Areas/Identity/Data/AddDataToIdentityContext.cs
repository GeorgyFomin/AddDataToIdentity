using AddDataToIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AddDataToIdentity.Data;

public class AddDataToIdentityContext : IdentityDbContext<AddDataToIdentityUser>
{
    public AddDataToIdentityContext(DbContextOptions<AddDataToIdentityContext> options)
        : base(options)
    {
    }

    public DbSet<Phone> Phone { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

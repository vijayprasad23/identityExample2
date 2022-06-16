using identityExample2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using identityExample2.Models;

namespace identityExample2.Areas.Identity.Data;

public class identityExample2ContextDb : IdentityDbContext<identityExample2User>
{
    public identityExample2ContextDb(DbContextOptions<identityExample2ContextDb> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<identityExample2.Models.Movie>? Movie { get; set; }
}

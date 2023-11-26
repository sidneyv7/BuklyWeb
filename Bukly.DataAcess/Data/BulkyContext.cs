using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bukly7.Bukly.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Bukly7.Bukly.DataAcess.Data;

public class BulkyContext : IdentityDbContext<IdentityUser>

{
    public BulkyContext()
    {
    }

    public BulkyContext(DbContextOptions<BulkyContext> options)
        : base(options)
    {
    }

  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bukly7.Bukly.Models;

namespace Bukly7.Bukly.DataAcess.Data;

public partial class BulkyContext : DbContext
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


  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );
    OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

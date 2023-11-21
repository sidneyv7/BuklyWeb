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


  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

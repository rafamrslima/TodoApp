using System;
using Microsoft.EntityFrameworkCore;
using MyApp.API.Core.Models;

namespace MyApp.API.Infrastructure;

public class MyAppDbContext : DbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasKey(p => p.Id);
    }
}
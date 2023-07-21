using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrizeWinnerAPI.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest>? Guests { get; set; }

    public virtual DbSet<Item>? Item { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=thefactorylondon-db.cjhy495rnkkn.us-west-2.rds.amazonaws.com;Database=TheFactoryDev;User Id=admin;Password=TheFactory2020;Persist Security Info=True;Encrypt=false;");

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

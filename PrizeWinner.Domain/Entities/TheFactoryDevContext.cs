using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrizeWinner.Domain.Entities;

public partial class TheFactoryDevContext : DbContext
{
    public TheFactoryDevContext()
    {
    }

    public TheFactoryDevContext(DbContextOptions<TheFactoryDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemGroup> ItemGroups { get; set; }

    public virtual DbSet<PromotionGroup> PromotionGroups { get; set; }

}

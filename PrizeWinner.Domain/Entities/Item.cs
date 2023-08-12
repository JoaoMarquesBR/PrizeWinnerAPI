using System;
using System.Collections.Generic;

namespace PrizeWinner.Domain.Entities;

public partial class Item
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<ItemGroup> ItemGroups { get; set; } = new List<ItemGroup>();
}

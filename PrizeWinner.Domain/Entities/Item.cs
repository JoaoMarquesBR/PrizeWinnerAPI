using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinnerAPI.Domain;

[Table("Item")]
public partial class Item
{
    public int ItemId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<ItemPromotionGroup> ItemPromotionGroups { get; set; } = new List<ItemPromotionGroup>();
}

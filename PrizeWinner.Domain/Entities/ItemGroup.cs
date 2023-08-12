using System;
using System.Collections.Generic;

namespace PrizeWinner.Domain.Entities;

public partial class ItemGroup
{
    public int ItemGroupId { get; set; }

    public int? ItemId { get; set; }

    public int? PromotionGroupId { get; set; }

    public virtual Item? Item { get; set; }

    public virtual PromotionGroup? PromotionGroup { get; set; }
}

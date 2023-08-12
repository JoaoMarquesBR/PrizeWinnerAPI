using System;
using System.Collections.Generic;

namespace PrizeWinner.Domain.Entities;

public partial class PromotionGroup
{
    public int PromotionGroupId { get; set; }

    public string? GroupName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<ItemGroup> ItemGroups { get; set; } = new List<ItemGroup>();
}

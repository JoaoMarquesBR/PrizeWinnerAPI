using PrizeWinnerAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinnerAPI.Domain;

[Table("PromotionGroup")]
public partial class PromotionGroup
{
    public int PromotionGroupId { get; set; }

    public string? GroupName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Guest> Guests { get; set; } = new List<Guest>();

    public virtual ICollection<ItemPromotionGroup> ItemPromotionGroups { get; set; } = new List<ItemPromotionGroup>();
}

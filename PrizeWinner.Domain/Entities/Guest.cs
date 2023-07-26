using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinnerAPI.Domain;

[Table("Guest")]
public partial class Guest
{
    public short GuestId { get; set; }

    public int PromotionGroupId { get; set; }

    public string? UserEmail { get; set; }

    public string? FirstName { get; set; }

    public virtual PromotionGroup PromotionGroup { get; set; } = null!;
}

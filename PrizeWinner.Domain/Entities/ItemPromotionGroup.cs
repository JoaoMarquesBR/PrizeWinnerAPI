
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinnerAPI.Domain;

public partial class ItemPromotionGroup
{
    public int ItemPromotionGroupId { get; set; }

    public int? PromotionGroupId { get; set; }

    public int? ItemId { get; set; }

    public virtual Item? Item { get; set; }

    public virtual PromotionGroup? PromotionGroup { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinner.Domain.Entities;

public partial class ItemGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ItemGroupId { get; set; }

    [ForeignKey("Item")]
    public int? ItemId { get; set; }

    [ForeignKey("PromotionGroup")]
    public int? PromotionGroupId { get; set; }

}

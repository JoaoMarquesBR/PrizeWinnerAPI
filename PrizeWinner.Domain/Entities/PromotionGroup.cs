using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinner.Domain.Entities;

public partial class PromotionGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PromotionGroupId { get; set; }

    [Required]
    [StringLength(80)]
    public string? GroupName { get; set; }

    [Required]
    public DateTime? CreatedDate { get; set; }

}

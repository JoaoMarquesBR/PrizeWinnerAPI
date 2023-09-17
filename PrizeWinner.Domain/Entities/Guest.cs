using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinner.Domain.Entities;

public partial class Guest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GuestId { get; set; }

    [ForeignKey("PromotionGroup")]
    public int? PromotionGroupId { get; set; }

    [MaxLength]
    public string? UserEmail { get; set; }

    [MaxLength(80)]
    public string? FirstName { get; set; }

    [MaxLength(80)]
    public string? LastName { get; set; }

    [Required]
    public DateTime? SignedInDate { get; set; }

    [Required]
    public DateTime? ExpiringDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace PrizeWinner.Domain.Entities;

public partial class Guest
{
    public int GuestId { get; set; }

    public int? GroupId { get; set; }

    public string? UserEmail { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? SignedInDate { get; set; }

    public DateTime? ExpiringDate { get; set; }
}

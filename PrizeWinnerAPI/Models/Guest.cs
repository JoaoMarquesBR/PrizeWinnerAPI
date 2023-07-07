using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinnerAPI.Models;

[Table("Guest")]
public partial class Guest
{
    public short GuestId { get; set; }

    public string? UserEmail { get; set; }

    public string? FirstName { get; set; }
}

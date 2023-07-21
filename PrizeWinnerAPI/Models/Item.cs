using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrizeWinnerAPI.Models;

[Table("Item")]
public partial class Item
{
    public short ItemId { get; set; }

    public string? name { get; set; }

    public double? price { get; set; }
}

using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public required int UserId { get; set; }

    public required int RestaurantId { get; set; }

    public required int Rating { get; set; }

    public required string Comment { get; set; }

    public required virtual Restaurant Restaurant { get; set; }

    public required virtual User User { get; set; }
}

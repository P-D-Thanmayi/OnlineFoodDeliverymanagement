using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public required int UserId { get; set; }

    public required int RestaurantId { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public required virtual Restaurant Restaurant { get; set; }

    public required virtual User User { get; set; }
}

using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class OrderItem
{
    public required int OrderId { get; set; }

    public required int ItemId { get; set; }

    public required int Quantity { get; set; }

    public required virtual FoodItem Item { get; set; }

    public required virtual Order Order { get; set; }
}

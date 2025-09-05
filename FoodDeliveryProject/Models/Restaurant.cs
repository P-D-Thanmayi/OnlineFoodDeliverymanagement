using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public required bool Status { get; set; }

    public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User RestaurantNavigation { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

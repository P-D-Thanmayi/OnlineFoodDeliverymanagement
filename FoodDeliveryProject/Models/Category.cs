using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public required string Name { get; set; }

    public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Models;

public partial class User
{

    public int Id { get; set; }

   
    public required string Name { get; set; }
    
    public required string Phoneno { get; set; }
    
    public required string Password { get; set; }
    
    public required bool IsValid { get; set; }
    
    public required string Role { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual DeliveryAgent? DeliveryAgent { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Restaurant? Restaurant { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

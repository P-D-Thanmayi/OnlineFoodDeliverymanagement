using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public required int CustId { get; set; }

    public required string Address1 { get; set; }

    public required virtual User Cust { get; set; }
}

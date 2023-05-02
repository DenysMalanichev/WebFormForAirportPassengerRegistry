using System;
using System.Collections.Generic;

namespace WebFormForAirportPassengerRegistry;

public partial class Search
{
    public int SearchId { get; set; }

    public DateTime DateSince { get; set; }

    public DateTime ExpiryDate { get; set; }

    public string Reason { get; set; } = null!;

    public int? PassengerId { get; set; }

    public string? FullName { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Sex { get; set; }

    public virtual Passenger? Passenger { get; set; }
}

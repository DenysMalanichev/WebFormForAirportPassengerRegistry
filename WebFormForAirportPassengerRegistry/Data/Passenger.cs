using System;
using System.Collections.Generic;

namespace WebFormForAirportPassengerRegistry;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string Citizenship { get; set; } = null!;

    public string Birthplace { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public string Sex { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Residency { get; set; } = null!;

    public string Communication { get; set; } = null!;

    public virtual ICollection<FlightTicket> FlightTickets { get; set; } = new List<FlightTicket>();

    public virtual ICollection<Search> Searches { get; set; } = new List<Search>();
}

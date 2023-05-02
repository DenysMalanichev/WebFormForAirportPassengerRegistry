using System;
using System.Collections.Generic;

namespace WebFormForAirportPassengerRegistry;

public partial class Terminal
{
    public int TerminalId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}

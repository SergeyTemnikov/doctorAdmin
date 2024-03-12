using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class Event
{
    public int Id { get; set; }

    public int IdPerson { get; set; }

    public DateTime Date { get; set; }

    public string TypeOfEvent { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Results { get; set; }

    public string? RecForTreatmenr { get; set; }

    public virtual Person IdPersonNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class Disease
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual ICollection<DiseasesToMedCard> DiseasesToMedCards { get; set; } = new List<DiseasesToMedCard>();
}

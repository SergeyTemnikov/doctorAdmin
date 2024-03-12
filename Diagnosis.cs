using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class Diagnosis
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DiagnosesToMedCard> DiagnosesToMedCards { get; set; } = new List<DiagnosesToMedCard>();
}

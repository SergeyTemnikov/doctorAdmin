using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class MedCard
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public DateTime DateOfReceiving { get; set; }

    public int? IdDiagnoses { get; set; }

    public int? IdDiseasesHistory { get; set; }

    public string QrNumber { get; set; } = null!;

    public virtual ICollection<DiagnosesToMedCard> DiagnosesToMedCards { get; set; } = new List<DiagnosesToMedCard>();

    public virtual ICollection<DiseasesToMedCard> DiseasesToMedCards { get; set; } = new List<DiseasesToMedCard>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<QrImage> QrImages { get; set; } = new List<QrImage>();
}

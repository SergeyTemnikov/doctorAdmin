using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class DiagnosesToMedCard
{
    public int Id { get; set; }

    public int IdMedCard { get; set; }

    public int IdDiagnoses { get; set; }

    public virtual Diagnosis IdDiagnosesNavigation { get; set; } = null!;

    public virtual MedCard IdMedCardNavigation { get; set; } = null!;
}

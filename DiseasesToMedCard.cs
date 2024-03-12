using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class DiseasesToMedCard
{
    public int Id { get; set; }

    public int IdMedCard { get; set; }

    public int IdDiseases { get; set; }

    public virtual Disease IdDiseasesNavigation { get; set; } = null!;

    public virtual MedCard IdMedCardNavigation { get; set; } = null!;
}

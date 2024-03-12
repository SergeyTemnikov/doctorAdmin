using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class MedInsurance
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public DateTime DateOfEnd { get; set; }

    public string InsuranceCompany { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}

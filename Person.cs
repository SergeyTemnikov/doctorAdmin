using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public string PassportData { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int? IdMedCard { get; set; }

    public int? IdMedInsurance { get; set; }

    public string Address { get; set; } = null!;

    public int? IdGender { get; set; }

    public string Email { get; set; } = null!;

    public string? Job { get; set; }

    public int? IdImage { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Gender? IdGenderNavigation { get; set; }

    public virtual Image? IdImageNavigation { get; set; }

    public virtual MedCard? IdMedCardNavigation { get; set; }

    public virtual MedInsurance? IdMedInsuranceNavigation { get; set; }

    public virtual ICollection<PersonImage> PersonImages { get; set; } = new List<PersonImage>();
}

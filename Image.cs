using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class Image
{
    public int Id { get; set; }

    public string Image1 { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<PersonImage> PersonImages { get; set; } = new List<PersonImage>();

    public virtual ICollection<QrImage> QrImages { get; set; } = new List<QrImage>();
}

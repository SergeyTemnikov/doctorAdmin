using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class PersonImage
{
    public int Id { get; set; }

    public int IdPerson { get; set; }

    public int IdImage { get; set; }

    public virtual Image IdImageNavigation { get; set; } = null!;

    public virtual Person IdPersonNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace doctorAdmin;

public partial class QrImage
{
    public int Id { get; set; }

    public int IdImage { get; set; }

    public int IdQr { get; set; }

    public virtual Image IdImageNavigation { get; set; } = null!;

    public virtual MedCard IdQrNavigation { get; set; } = null!;
}

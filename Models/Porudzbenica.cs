using System;
using System.Collections.Generic;

namespace Teretana.Models;

public partial class Porudzbenica
{
    public int PorudzbenicaId { get; set; }

    public DateTime DatumKreiranja { get; set; }

    public double CenaPorudzbenice { get; set; }

    public string RadnikId { get; set; } = null!;

    public string DobavljacId { get; set; } = null!;

    public virtual Dobavljac Dobavljac { get; set; } = null!;

    public virtual Radnik Radnik { get; set; } = null!;

    public virtual ICollection<StavkaPorudzbenice> StavkaPorudzbenices { get; } = new List<StavkaPorudzbenice>();
}

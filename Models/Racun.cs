using System;
using System.Collections.Generic;

namespace Teretana.Models;

public partial class Racun
{
    public int RacunId { get; set; }

    public DateTime DatumKreiranja { get; set; }

    public double CenaRacuna { get; set; }

    public int KlijentId { get; set; }

    public bool Uknjizen { get; set; }

    public virtual Klijent Klijent { get; set; } = null!;

    public virtual ICollection<StavkaRacuna> StavkaRacunas { get; } = new List<StavkaRacuna>();
}

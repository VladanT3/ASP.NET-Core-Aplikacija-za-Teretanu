using System;
using System.Collections.Generic;

namespace Teretana.Models;

public partial class StavkaRacuna
{
    public int RacunId { get; set; }

    public int StavkaId { get; set; }

    public string ProizvodId { get; set; } = null!;

    public string NazivStavke { get; set; } = null!;

    public double CenaStavke { get; set; }

    public int Kolicina { get; set; }

    public virtual Proizvod Proizvod { get; set; } = null!;

    public virtual Racun Racun { get; set; } = null!;
}

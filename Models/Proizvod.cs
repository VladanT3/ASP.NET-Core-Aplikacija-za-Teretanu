using System;
using System.Collections.Generic;

namespace Teretana.Models;

public partial class Proizvod
{
    public string ProizvodId { get; set; } = null!;

    public string NazivProizvoda { get; set; } = null!;

    public int Kolicina { get; set; }

    public double NabavnaCena { get; set; }

    public double ProdajnaCena { get; set; }

    public string? Slika { get; set; }

    public virtual ICollection<StavkaPorudzbenice> StavkaPorudzbenices { get; } = new List<StavkaPorudzbenice>();

    public virtual ICollection<StavkaRacuna> StavkaRacunas { get; } = new List<StavkaRacuna>();
}

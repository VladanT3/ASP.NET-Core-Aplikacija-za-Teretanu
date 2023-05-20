using System;
using System.Collections.Generic;

namespace Teretana.Models;

public partial class Clanarina
{
    public string ClanarinaId { get; set; } = null!;

    public string NazivClanarine { get; set; } = null!;

    public double CenaClanarine { get; set; }

    public int BrojTermina { get; set; }

    public virtual ICollection<Klijent> Klijents { get; } = new List<Klijent>();
}

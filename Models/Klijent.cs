using System;
using System.Collections.Generic;

namespace Teretana.Models;

public partial class Klijent
{
    public int KlijentId { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sifra { get; set; } = null!;

    public DateTime DatumRodjenja { get; set; }

    public string Adresa { get; set; } = null!;

    public string BrojTelefona { get; set; } = null!;

    public string ClanarinaId { get; set; } = null!;

    public DateTime DatumPocetkaClanarine { get; set; }

    public DateTime DatumIstekaClanarine { get; set; }

    public int BrojTermina { get; set; }

    public virtual Clanarina Clanarina { get; set; } = null!;

    public virtual ICollection<Racun> Racuns { get; } = new List<Racun>();
}

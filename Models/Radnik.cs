using System;
using System.Collections.Generic;

namespace Teretana.Models;

public partial class Radnik
{
    public string RadnikId { get; set; } = null!;

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sifra { get; set; } = null!;

    public DateTime DatumRodjenja { get; set; }

    public string Adresa { get; set; } = null!;

    public string BrojTelefona { get; set; } = null!;

    public virtual ICollection<Porudzbenica> Porudzbenicas { get; } = new List<Porudzbenica>();
}

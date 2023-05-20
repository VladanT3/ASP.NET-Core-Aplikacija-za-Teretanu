using System;
using System.Collections.Generic;

namespace Teretana.Models;

public partial class Dobavljac
{
    public string DobavljacId { get; set; } = null!;

    public string NazivDobavljaca { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string BrojTelefona { get; set; } = null!;

    public string Adresa { get; set; } = null!;

    public virtual ICollection<Porudzbenica> Porudzbenicas { get; } = new List<Porudzbenica>();
}

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Teretana.Models
{
	public class RadnikBO
	{
		public string RadnikId { get; set; }

		[Display(Name = "Ime:")]
		public string Ime { get; set; }

		[Display(Name = "Prezime:")]
		public string Prezime { get; set; }

		[Display(Name = "E-mail:")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "Šifra:")]
		[DataType(DataType.Password)]
		public string Sifra { get; set; }

		[Display(Name = "Datum Rodjenja:")]
		[DataType(DataType.Date)]
		public DateTime DatumRodjenja { get; set; }

		public string Adresa { get; set; }

		[Display(Name = "Broj Telefona:")]
		public string BrojTelefona { get; set; }

		[Display(Name = "Ime i Prezime:")]
		public string ImePrezime { get { return Ime + " " + Prezime; } }
	}
}

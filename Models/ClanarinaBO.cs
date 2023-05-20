using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Teretana.Models
{
	public class ClanarinaBO
	{
		public string ClanarinaId { get; set; }
		public string NazivClanarine { get; set; }
		[Display(Name = "Cena:")]
		public double CenaClanarine { get; set; }
		[Display(Name = "Broj termina:")]
		public int BrojTermina { get; set; }
	}
}

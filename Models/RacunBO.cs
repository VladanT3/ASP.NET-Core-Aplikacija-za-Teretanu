namespace Teretana.Models
{
	public class RacunBO
	{
		public int RacunId { get; set; }
		public DateTime DatumKreiranja { get; set; }
		public double CenaRacuna { get; set; }
		public int KlijentId { get; set; }
		public bool Uknjizen { get; set; }
	}
}

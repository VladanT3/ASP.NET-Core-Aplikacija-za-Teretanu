namespace Teretana.Models
{
	public class PorudzbenicaBO
	{
		public int PorudzbenicaId { get; set; }
		public DateTime DatumKreiranja { get; set; }
		public double CenaPorudzbenice { get; set; }
		public string RadnikId { get; set; }
		public string DobavljacId { get; set; }
	}
}

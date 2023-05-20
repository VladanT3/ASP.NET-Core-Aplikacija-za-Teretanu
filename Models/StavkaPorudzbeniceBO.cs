namespace Teretana.Models
{
	public class StavkaPorudzbeniceBO
	{
		public int PorudzbenicaId { get; set; }
		public int StavkaId { get; set; }
		public string ProizvodId { get; set; }
		public string NazivStavke { get; set; }
		public double CenaStavke { get; set; }
		public int Kolicina { get; set; }
	}
}

namespace Teretana.Models.Interfaces
{
	public interface IAccountRepository
	{
		string Ulogovanje(string email, string sifra);
		string NapraviNalog(KlijentBO klijent);
		void ObrisiNalog(int id);
		KlijentBO VratiKlijenta(int id);
		RadnikBO VratiRadnika(string id);
		string VratiNazivClanarine(int klijentID);
		string IzmenaPodataka(KlijentBO noviPodaci);
		List<KlijentBO> OcitavanjeKlijenta(List<KlijentBO> klijenti, KlijentBO noviKlijent);
	}
}

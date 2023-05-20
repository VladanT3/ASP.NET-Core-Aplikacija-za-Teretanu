namespace Teretana.Models.Interfaces
{
    public interface IProdavnicaRepository
    {
        StavkaRacunaBO PrebaciProizvodUStavku(string proizvodID, int kolicina);
        double VratiUkupnuCenu(List<StavkaRacunaBO> korpa);
        List<StavkaRacunaBO> AzurirajKorpu(List<StavkaRacunaBO> korpa, StavkaRacunaBO noviProizvod);
        List<StavkaRacunaBO> AzurirajKolicinu(List<StavkaRacunaBO> korpa, ProizvodBO proizvod);
        List<StavkaRacunaBO> ObrisiProizvod(List<StavkaRacunaBO> korpa, string idProizvoda);
        void NapraviRacun(List<StavkaRacunaBO> korpa, double ukupnaCena);
    }
}

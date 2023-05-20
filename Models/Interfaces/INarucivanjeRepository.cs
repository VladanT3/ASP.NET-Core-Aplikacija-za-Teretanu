namespace Teretana.Models.Interfaces
{
    public interface INarucivanjeRepository
    {
        StavkaPorudzbeniceBO PrebaciProizvodUStavku(string proizvodID);
        List<DobavljacBO> VratiDobavljace();
        void NapraviPorudzbenicu(List<StavkaPorudzbeniceBO> stavke, double ukupnaCena, string dobavljacID);
        List<StavkaPorudzbeniceBO> AzurirajStavke(List<StavkaPorudzbeniceBO> stavke, StavkaPorudzbeniceBO novaStavka);
        double VratiUkupnuCenu(List<StavkaPorudzbeniceBO> stavke);
        List<StavkaPorudzbeniceBO> BrisanjeStavke(List<StavkaPorudzbeniceBO> stavke, string idProizvoda);
    }
}

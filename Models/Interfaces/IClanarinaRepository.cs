namespace Teretana.Models.Interfaces
{
    public interface IClanarinaRepository
    {
        List<ClanarinaBO> VratiClanarine();
        void DodeliClanarinu(int id, string clanarina, int brojTermina);
    }
}

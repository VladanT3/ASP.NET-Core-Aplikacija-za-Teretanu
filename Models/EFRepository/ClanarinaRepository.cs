using Teretana.Models.Interfaces;

namespace Teretana.Models.EFRepository
{
    public class ClanarinaRepository : IClanarinaRepository
    {
        private TeretanaContext teretana = new TeretanaContext();

        public List<ClanarinaBO> VratiClanarine()
        {
            List<ClanarinaBO> clanarine = new List<ClanarinaBO>();

            foreach(var clanarina in teretana.Clanarinas.Where(c => c.ClanarinaId != "N0").ToList())
            {
                ClanarinaBO clanarinaBO = new ClanarinaBO()
                {
                    ClanarinaId = clanarina.ClanarinaId,
                    NazivClanarine = clanarina.NazivClanarine,
                    CenaClanarine = clanarina.CenaClanarine,
                    BrojTermina = clanarina.BrojTermina
                };
                clanarine.Add(clanarinaBO);
            }

            return clanarine;
        }
        public void DodeliClanarinu(int id, string clanarina, int brojTermina)
        {
            Klijent klijent = teretana.Klijents.Where(k => k.KlijentId == id).Single();
            if(klijent.ClanarinaId != "N0")
            {
                klijent.ClanarinaId = clanarina;
                klijent.BrojTermina += brojTermina;
                klijent.DatumIstekaClanarine = klijent.DatumIstekaClanarine.AddMonths(1);
            }
            else
            {
                klijent.ClanarinaId = clanarina;
                klijent.BrojTermina += brojTermina;
                klijent.DatumPocetkaClanarine = DateTime.Now;
                klijent.DatumIstekaClanarine = DateTime.Now.AddMonths(1);
            }
            teretana.SaveChanges();
        }
    }
}

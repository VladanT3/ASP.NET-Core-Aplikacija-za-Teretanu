using Teretana.Models.Interfaces;

namespace Teretana.Models.EFRepository
{
    public class RacunRepository : IRacunRepository
    {
        private TeretanaContext teretana = new TeretanaContext();

        public void UknjiziRacune(int[] ids)
        {
            foreach(int racunID in ids)
            {
                Racun racun = teretana.Racuns.Where(r => r.RacunId == racunID).Single();
                racun.Uknjizen = true;
            }
            teretana.SaveChanges();
        }

        public List<RacunBO> VratiNeuknjizeneRacune()
        {
            List<RacunBO> racuni = new List<RacunBO>();

            foreach(var racun in teretana.Racuns.Where(r => r.Uknjizen == false).ToList())
            {
                RacunBO racunBO = new RacunBO()
                {
                    RacunId = racun.RacunId,
                    DatumKreiranja = racun.DatumKreiranja,
                    CenaRacuna = racun.CenaRacuna,
                    KlijentId = racun.KlijentId,
                    Uknjizen = racun.Uknjizen
                };
                racuni.Add(racunBO);
            }

            return racuni;
        }

        public List<StavkaRacunaBO> VratiStavkeRacuna(int id)
        {
            List<StavkaRacunaBO> racuni = new List<StavkaRacunaBO>();
            foreach(var stavka in teretana.StavkaRacunas.Where(sr => sr.RacunId == id).ToList())
            {
                StavkaRacunaBO stavkaBO = new StavkaRacunaBO()
                {
                    RacunId = stavka.RacunId,
                    StavkaId = stavka.StavkaId,
                    ProizvodId = stavka.ProizvodId,
                    NazivStavke = stavka.NazivStavke,
                    CenaStavke = stavka.CenaStavke,
                    Kolicina = stavka.Kolicina
                };
                racuni.Add(stavkaBO);
            }

            return racuni;
        }
    }
}

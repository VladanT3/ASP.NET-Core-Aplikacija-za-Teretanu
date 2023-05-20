using Teretana.Models.Interfaces;

namespace Teretana.Models.EFRepository
{
    public class NarucivanjeRepository : INarucivanjeRepository
    {
        private TeretanaContext teretana = new TeretanaContext();

        public StavkaPorudzbeniceBO PrebaciProizvodUStavku(string proizvodID)
        {
            Proizvod proizvod = teretana.Proizvods.Where(p => p.ProizvodId == proizvodID).Single();
            StavkaPorudzbeniceBO stavkaBO = new StavkaPorudzbeniceBO()
            {
                ProizvodId = proizvod.ProizvodId,
                NazivStavke = proizvod.NazivProizvoda,
                CenaStavke = proizvod.NabavnaCena,
                Kolicina = 0
            };
            return stavkaBO;
        }
        public List<DobavljacBO> VratiDobavljace()
        {
            List<DobavljacBO> dobavljaci = new List<DobavljacBO>();
            foreach(Dobavljac dobavljac in teretana.Dobavljacs)
            {
                DobavljacBO dobavljacBO = new DobavljacBO()
                {
                    DobavljacId = dobavljac.DobavljacId,
                    NazivDobavljaca = dobavljac.NazivDobavljaca
                };
                dobavljaci.Add(dobavljacBO);
            }
            return dobavljaci;
        }
        public void NapraviPorudzbenicu(List<StavkaPorudzbeniceBO> stavke, double ukupnaCena, string dobavljacID)
        {
            Porudzbenica porudzbenica = new Porudzbenica()
            {
                DatumKreiranja = DateTime.Now,
                CenaPorudzbenice = ukupnaCena,
                RadnikId = Ulogovan.UlogovanRadnik,
                DobavljacId = dobavljacID
            };
            teretana.Porudzbenicas.Add(porudzbenica);
            teretana.SaveChanges();

            int novaPorudzbenica = teretana.Porudzbenicas.Max(p => p.PorudzbenicaId);

            foreach(StavkaPorudzbeniceBO stavka in stavke)
            {
                StavkaPorudzbenice stavkaPorudzbenice = new StavkaPorudzbenice()
                {
                    PorudzbenicaId = novaPorudzbenica,
                    ProizvodId = stavka.ProizvodId,
                    NazivStavke = stavka.NazivStavke,
                    CenaStavke = stavka.CenaStavke * stavka.Kolicina,
                    Kolicina = stavka.Kolicina
                };
                teretana.StavkaPorudzbenices.Add(stavkaPorudzbenice);

                Proizvod proizvod = teretana.Proizvods.Where(p => p.ProizvodId == stavka.ProizvodId).Single();
                proizvod.Kolicina += stavka.Kolicina;
            }
            teretana.SaveChanges();
        }

        public List<StavkaPorudzbeniceBO> AzurirajStavke(List<StavkaPorudzbeniceBO> stavke, StavkaPorudzbeniceBO novaStavka)
        {
            bool provera = true;
            foreach(StavkaPorudzbeniceBO s in stavke)
            {
                if(s.ProizvodId == novaStavka.ProizvodId)
                {
                    s.Kolicina += novaStavka.Kolicina;
                    provera = false;
                }
            }
            if (provera)
            {
                stavke.Add(novaStavka);
            }
            return stavke;
        }

        public double VratiUkupnuCenu(List<StavkaPorudzbeniceBO> stavke)
        {
            double ukupnaCena = 0;
            foreach(StavkaPorudzbeniceBO s in stavke)
            {
                ukupnaCena += s.CenaStavke * s.Kolicina;
            }
            return ukupnaCena;
        }

        public List<StavkaPorudzbeniceBO> BrisanjeStavke(List<StavkaPorudzbeniceBO> stavke, string idProizvoda)
        {
            int i = 0;
            foreach(StavkaPorudzbeniceBO s in stavke)
            {
                if(s.ProizvodId == idProizvoda)
                    break;
                i++;
            }
            stavke.RemoveAt(i);
            return stavke;
        }
    }
}

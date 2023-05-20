using Teretana.Models.Interfaces;

namespace Teretana.Models.EFRepository
{
    public class ProdavnicaRepository : IProdavnicaRepository
    {
        TeretanaContext teretana = new TeretanaContext();

        public StavkaRacunaBO PrebaciProizvodUStavku(string proizvodID, int kolicina)
        {
            Proizvod proizvod = teretana.Proizvods.Where(p => p.ProizvodId == proizvodID).Single();
            StavkaRacunaBO stavkaRacuna = new StavkaRacunaBO()
            {
                ProizvodId = proizvod.ProizvodId,
                NazivStavke = proizvod.NazivProizvoda,
                CenaStavke = proizvod.ProdajnaCena * kolicina,
                Kolicina = kolicina
            };
            return stavkaRacuna;
        }

        public double VratiUkupnuCenu(List<StavkaRacunaBO> korpa)
        {
            double ukupnaCena = 0;
            foreach (var item in korpa)
            {
                ukupnaCena += item.CenaStavke;
            }
            return ukupnaCena;
        }

        public List<StavkaRacunaBO> AzurirajKorpu(List<StavkaRacunaBO> korpa, StavkaRacunaBO noviProizvod)
        {
            List<StavkaRacunaBO> novaKorpa = new List<StavkaRacunaBO>();
            bool nov = true;

            if(korpa.Count == 0)
            {
                novaKorpa.Add(noviProizvod);
                return novaKorpa;
            }

            foreach(StavkaRacunaBO stavka in korpa)
            {
                if(stavka.ProizvodId == noviProizvod.ProizvodId)
                {
                    nov = false;
                    stavka.Kolicina += noviProizvod.Kolicina;
                    stavka.CenaStavke += noviProizvod.CenaStavke;

                    novaKorpa.Add(stavka);
                }
                else
                {
                    novaKorpa.Add(stavka);
                }
            }

            if (nov)
            {
                novaKorpa.Add(noviProizvod);
                return novaKorpa;
            }
            return novaKorpa;
        }

        public List<StavkaRacunaBO> AzurirajKolicinu(List<StavkaRacunaBO> korpa, ProizvodBO proizvod)
        {
            List<StavkaRacunaBO> novaKorpa = new List<StavkaRacunaBO>();

            foreach (StavkaRacunaBO stavka in korpa)
            {
                if(stavka.ProizvodId == proizvod.ProizvodId)
                {
                    stavka.Kolicina--;
                    if (stavka.Kolicina == 0)
                    {
                        return ObrisiProizvod(korpa, proizvod.ProizvodId);
                    }
                    stavka.CenaStavke = stavka.Kolicina * proizvod.ProdajnaCena;
                }
                novaKorpa.Add(stavka);
            }
            return novaKorpa;
        }

        public List<StavkaRacunaBO> ObrisiProizvod(List<StavkaRacunaBO> korpa, string idProizvoda)
        {
            int i = 0;

            foreach (StavkaRacunaBO stavka in korpa)
            {
                if (stavka.ProizvodId == idProizvoda)
                    break;

                i++;
            }

            korpa.RemoveAt(i);
            return korpa;
        }

        public void NapraviRacun(List<StavkaRacunaBO> korpa, double ukupnaCena)
        {
            Racun racun = new Racun()
            {
                DatumKreiranja = DateTime.Now,
                CenaRacuna = ukupnaCena,
                KlijentId = Ulogovan.UlogovanKlijent,
                Uknjizen = false
            };
            teretana.Racuns.Add(racun);
            teretana.SaveChanges();

            int noviRacun = teretana.Racuns.Max(r => r.RacunId);

            foreach(var stavka in korpa)
            {
                StavkaRacuna stavkaRacuna = new StavkaRacuna()
                {
                    RacunId = noviRacun,
                    ProizvodId = stavka.ProizvodId,
                    NazivStavke = stavka.NazivStavke,
                    CenaStavke = stavka.CenaStavke,
                    Kolicina = stavka.Kolicina
                };
                teretana.StavkaRacunas.Add(stavkaRacuna);

                Proizvod proizvod = teretana.Proizvods.Where(p => p.ProizvodId == stavka.ProizvodId).Single();
                proizvod.Kolicina -= stavka.Kolicina;
            }
            teretana.SaveChanges();
        }
    }
}

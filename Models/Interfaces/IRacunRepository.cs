namespace Teretana.Models.Interfaces
{
    public interface IRacunRepository
    {
        List<RacunBO> VratiNeuknjizeneRacune();
        void UknjiziRacune(int[] ids);
        List<StavkaRacunaBO> VratiStavkeRacuna(int id);
    }
}

using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IWineCellerRepo
    {
        void Create(WineCeller wineCeller);

        List<WineCeller> GetAll();

        void Update(WineCeller wineCeller);

        void Delete(int wineCeller_id);

        WineCeller GetByIdWineCeller(int wineCeller_id);

        WineCeller GetName(string Name);




    }
}

using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace DataAccessLayer.Repositories.FakeRepos
{
    public class FakeWineCellerRepo : IWineCellerRepo
    {
        public List<WineCeller> _wineCellers { get; set; }

        public FakeWineCellerRepo()
        {

           _wineCellers = new List<WineCeller>()
           {
           new WineCeller(1, "Bob", 1955, "Modern", "bob@gmail.com", "North", "Framce"),
           new WineCeller(2, "Tom", 1955, "Classic", "Tom@gmail.com", "North", "Macedoni"),
           new WineCeller(3, "Dan", 1955, "Unique", "Dan@gmail.com", "North", "Germany")
            
        };
        }

        public void Create(WineCeller wineCeller)
        {
            _wineCellers.Add(wineCeller);
        }

        public List<WineCeller> GetAll()
        {
            return _wineCellers;
        }


        public void Delete(int wineCeller_id)
        {
            WineCeller deleteWC = _wineCellers.FirstOrDefault(w => w.Id == wineCeller_id);
            if (deleteWC != null)
            {
                _wineCellers.Remove(deleteWC);
            }
        }

        public WineCeller GetByIdWineCeller(int wineCeller_id)
        {
            return _wineCellers.FirstOrDefault(wc => wc.Id == wineCeller_id);
        }

        public WineCeller GetName(string Name)
        {
            return _wineCellers.FirstOrDefault(wc => wc.Name == Name);
        }


        public void Update(WineCeller wineCeller)
        {
            WineCeller UpdatedWC = _wineCellers.FirstOrDefault(wc => wc.Id == wineCeller.Id);
            if(UpdatedWC != null)
            {
                UpdatedWC.Name = wineCeller.Name;
                UpdatedWC.YearCreated = wineCeller.YearCreated;
                UpdatedWC.WineStyle = wineCeller.WineStyle;
                UpdatedWC.Email = wineCeller.Email;
                UpdatedWC.Region = wineCeller.Region;
                UpdatedWC.Country = wineCeller.Country;
            }



           
        }

    }
}




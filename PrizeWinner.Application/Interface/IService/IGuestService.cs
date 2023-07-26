using PrizeWinnerAPI.Domain;


namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IGuestService<T> : IGenericRepository<T> where T : Guest
    {
       //Task<Guest> GetRandom();

    }
}

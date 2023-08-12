using PrizeWinner.Domain.Entities;


namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IGuestService<T> : IGenericRepository<T> where T : Guest
    {
        //Task<Guest> GetRandom();

        Task<IEnumerable<Guest>> GetGuestsByGroupID(int groupID);

    }
}

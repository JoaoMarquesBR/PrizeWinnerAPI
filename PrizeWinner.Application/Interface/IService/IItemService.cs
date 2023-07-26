using PrizeWinnerAPI.Domain;


namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IItemService<T> : IGenericRepository<T> where T : Item
    {

    }
}

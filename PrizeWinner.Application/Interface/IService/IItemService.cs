using PrizeWinner.Domain.Entities;


namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IItemService<T> : IGenericRepository<T> where T : Item
    {

    }
}

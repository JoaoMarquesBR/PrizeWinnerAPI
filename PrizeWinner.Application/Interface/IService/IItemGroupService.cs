using PrizeWinner.Domain.Entities;


namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IItemGroupService<T> : IGenericRepository<T> where T : ItemGroup
    {

    }
}

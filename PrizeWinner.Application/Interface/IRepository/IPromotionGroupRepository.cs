using PrizeWinner.Domain.Entities;


namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IPromotionGroupRepository
    {
        Task Add(PromotionGroup entity);

        Task<IEnumerable<PromotionGroup>> GetAll();

    }
}

using CareNestSolution.Chat.Domain.Model.Entities;
using CareNestSolution.Shared.Domain.Respositories;

 namespace CareNestSolution.Chat.Domain.Repositories{
    public interface IChatRepository : IBaseRepository<ChatEntity>
    {
        Task<IEnumerable<ChatEntity>> GetByParentIdAsync(int parentId);
        Task<IEnumerable<ChatEntity>> GetByCaregiverIdAsync(int caregiverId);
    }
}
using Steam.Domain.Database.SqlServer.Entities;

namespace Steam.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> Get(Guid userId);
        IQueryable<User> Queryable();
        Task<bool> IfExists(Guid userId);
        Task<User> Update(User user);

    }
}

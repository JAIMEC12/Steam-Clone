using Microsoft.EntityFrameworkCore;
using Steam.Domain.Database.SqlServer.Context;
using Steam.Domain.Database.SqlServer.Entities;
using Steam.Domain.Interfaces.Repositories;

namespace Steam.Infrastructure.Persistence.SqlServer.Repositories
{
    public class UserRepository(SteamContext context) : IUserRepository
    {
        public async Task<User> Create(User user)
        {
            try
            {
                //Insert the user into the database
                await context.Users.AddAsync(user);

                //Save the changes to the database
                await context.SaveChangesAsync();

                //Return the created user
                return user;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User?> Get(Guid userId)
        {
            try
            {
                return await context.Users.FirstOrDefaultAsync(x => x.UserId == userId && x.DeletedAt == null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfExists(Guid userId)
        {
            try
            {
                return await context.Users.AnyAsync(x => x.UserId == userId);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IQueryable<User> Queryable()
        {
            try
            {
                return context.Users.Where(x => x.DeletedAt == null).AsQueryable();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> Update(User user)
        {
            try
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Repository
{
    public class UserRepository : Repository<User, string>, IUserRepository
    {
        public UserRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}

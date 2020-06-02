using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Repository
{
    public class UserInfoRepository : Repository<Reviews, string>, IUserInfoRepository
    {
        public UserInfoRepository(IUnitOfWork uow): base(uow)
        {

        }
    }
}

using Application.Repositories;
using Domain.Entities;

namespace Infrastructure.Services;

public class UserService : CommonService<User>, IUserService
{
    public UserService(ICommonRepositories<User> repositories) : base(repositories)
    {
    }
}
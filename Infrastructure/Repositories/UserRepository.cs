using Application.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Nest;

namespace Infrastructure.Repositories;

public class UserRepository:CommonRepository<User> , IUserRepository
{
    public UserRepository(IConfiguration configuration, IElasticClient client) : base(configuration, client)
    {
    }
}
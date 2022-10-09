using Application.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Nest;

namespace Infrastructure.Repositories;

public class MessageRepository:CommonRepository<Message> , IMessageRepository
{
    public MessageRepository(IConfiguration configuration, IElasticClient client) : base(configuration, client)
    {
    }
}
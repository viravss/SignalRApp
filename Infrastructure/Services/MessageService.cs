using Application.Repositories;
using Domain.Entities;

namespace Infrastructure.Services;

public class MessageService : CommonService<Message>, IMessageService
{
    public MessageService(ICommonRepositories<Message> repositories) : base(repositories)
    {
    }
}
using Domain.Common;

namespace Domain.Entities;

public class Message:BaseEntity
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string MessageBody { get; set; }
}
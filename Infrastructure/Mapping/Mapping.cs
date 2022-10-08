using Domain.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Mapping;
using Nest;
public static class Mapping
{
    public static CreateIndexDescriptor UserMapping(this CreateIndexDescriptor descriptor)
    {
        return descriptor.Map<User>(m => m.Properties(p => p
            .Keyword(k => k.Name(n => n.Id))
            .Text(k => k.Name(n => n.UserName))
            .Text(k => k.Name(n => n.Password))
            .Text(k => k.Name(n => n.FullName))
            .Date(k => k.Name(n => n.CreatedOn))
            .Boolean(k => k.Name(n => n.IsActive))
        ));




    }
    public static CreateIndexDescriptor MessageMapping(this CreateIndexDescriptor descriptor)
    {
        return descriptor.Map<Message>(m => m.Properties(p => p
            .Keyword(k => k.Name(n => n.Id))
            .Text(k => k.Name(n => n.MessageBody))
            .Text(k => k.Name(n => n.ReceiverId))
            .Text(k => k.Name(n => n.SenderId))
            .Date(k => k.Name(n => n.CreatedOn))
        ));
    }
}
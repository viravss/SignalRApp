using Domain.Common;

namespace Domain.Entities;

public class User:BaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public string FullName { get; set; }
}
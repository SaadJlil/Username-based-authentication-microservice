using Domain.Common.Enums;

namespace Domain.Models;

public class Users : BasedEntity<Guid>
{
    public string Username { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public Permissions Permission { get; set; }
}
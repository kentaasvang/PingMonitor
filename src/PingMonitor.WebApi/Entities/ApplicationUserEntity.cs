using Microsoft.AspNetCore.Identity;

namespace PingMonitor.WebApi.Entities;

public class ApplicationUserEntity : IdentityUser<Guid>
{
    public List<DomainEntity> Domains { get; set; } = new();
}

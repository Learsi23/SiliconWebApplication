

namespace Infrastructure.Entities;

public class SubscriberEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Email { get; set; } = null!;
}

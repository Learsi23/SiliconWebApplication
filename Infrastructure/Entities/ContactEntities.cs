

namespace Infrastructure.Entities;

public class ContactEntities
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string Service { get; set; } = null!;
    public string Message { get; set; } = null!;
}



using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set;} = null!;

    [ProtectedPersonalData]
    public string? Bio {  get; set; }

    public string? ProfilImage { get; set; } = "avatar-image.svg";

    public bool IsExternal { get; set; }

    public ICollection<AddressEntity> Addresses { get; set; } = [];
}

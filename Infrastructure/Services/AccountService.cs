
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace Infrastructure.Services; 

public class AccountService(UserManager<UserEntity> userManager, AppDbContext context, IConfiguration configuration)
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AppDbContext _context = context;
    private readonly IConfiguration _configuration = configuration;
   

    public async Task<bool> UploadUserImageAsync(ClaimsPrincipal userClaims, IFormFile file)
    {
        try
        {
            if (userClaims != null && file != null && file.Length != 0)
            {
                var userEntity = await _userManager.GetUserAsync(userClaims);
                if (userEntity != null)
                {
                    var fileName = $"p_{userEntity.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FileUploadPath"]!, fileName);

                    using var fs = new FileStream(filePath,FileMode.Create);
                    await file.CopyToAsync(fs);

                    userEntity.ProfilImage = fileName;
                    _context.Update(userEntity);
                    await _context.SaveChangesAsync();
                    return true;

                }
            }
        
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }




}

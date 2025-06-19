using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using SiliconWebApplication.DTOs;

namespace SiliconWebApplication.Controllers;


public class ContactController : Controller
{
    private readonly AppDbContext _context;

    public ContactController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Contact()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SendRequest(ContactDto Dto)
    {
        if (ModelState.IsValid)
        {
            var contactEntity = new ContactEntities
            {
                FullName = Dto.FullName,
                EmailAddress = Dto.EmailAddress,
                Service = Dto.Service,
                Message = Dto.Message
            };

          
            _context.Contacts.Add(contactEntity);
            await _context.SaveChangesAsync();

            return RedirectToAction("Home", "Home"); 
        }

        return View("Contact");
    }
}

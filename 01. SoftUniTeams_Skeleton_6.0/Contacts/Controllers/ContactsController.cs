using Contacts.Data;
using Contacts.Data.Entities;
using Contacts.Models.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        public ContactsController(ContactsDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        ContactsDbContext context;
        UserManager<ApplicationUser> userManager;

        
        public async Task<IActionResult> All()
        {
            
            ICollection<ContactViewModel> model = await context.Contacts
                .Select(c=> new ContactViewModel()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    Email = c.Email,
                    Website = c.Website,
                    PhoneNumber = c.PhoneNumber
                    
                })
                .ToArrayAsync();
            return View(model);
        }

        public async Task<IActionResult> Team()
        {

            var user = await context.ApplicationUsers
            .Include(user => user.Contacts)
            .FirstAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            var contacts = user.Contacts.Select(c => new ContactViewModel()
            {
                Id=c.Id,
                FirstName=c.FirstName,
                LastName=c.LastName,
                Address=c.Address,
                PhoneNumber=c.PhoneNumber,
                Email=c.Email,
                Website=c.Website
            }).ToArray();

            var model = new TeamViewModel()
            {
                Contacts = contacts
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Add(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await context.Contacts.AddAsync(new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            });
            await context.SaveChangesAsync();

            return RedirectToAction("All","Contacts");

        }

        public async Task<IActionResult> AddToTeam(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await context.ApplicationUsers
                .Include(u => u.Contacts)
                .FirstAsync(u=> u.Id == userId);


            var contact = await context.Contacts
                .FirstAsync(c => c.Id == id);

            user.Contacts.Add(contact);
            await context.SaveChangesAsync();

            return RedirectToAction("Team", "Contacts");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var contact = await context.Contacts.FirstAsync(c => c.Id == id);
            ContactFormViewModel model = new ContactFormViewModel()
            {
                FirstName = contact.FirstName,
                LastName= contact.LastName,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                Website = contact.Website,
                Address = contact.Address  
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContactFormViewModel model)
        {
            
            var contact = await context.Contacts.FirstAsync(c => c.Id == id);
            contact.PhoneNumber = model.PhoneNumber;
            contact.Email = model.Email;
            contact.Website = model.Website;
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Address = model.Address;

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Contacts");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            var user = await context.ApplicationUsers
                .Include(user=>user.Contacts)
                .FirstAsync(u=> u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var contact = await context.Contacts.FirstAsync(c=> c.Id == id);

            user.Contacts.Remove(contact);

            await context.SaveChangesAsync();

            return RedirectToAction("Team", "Contacts");

        }

    }
}

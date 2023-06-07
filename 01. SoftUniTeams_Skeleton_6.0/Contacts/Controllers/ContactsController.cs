using Contacts.Data;
using Contacts.Data.Entities;
using Contacts.Models.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class ContactsController : Controller
    {
        public ContactsController(ContactsDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        ContactsDbContext context;
        UserManager<ApplicationUser> userManager;
        [Authorize]
        public IActionResult All()
        {
            
            ICollection<ContactViewModel> model = context.Contacts
                .Select(c=> new ContactViewModel()
                {
                    ContactId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    Email = c.Email,
                    Website = c.Website,
                    PhoneNumber = c.PhoneNumber
                    
                })
                .ToArray();
            return View(model);
        }

        public IActionResult Team()
        {

            TeamViewModel model = new TeamViewModel()
            {
                Contacts = context.ApplicationUsers
                .FindAsync(userManager.FindByNameAsync(User.Identity.Name).Result.Id)
                .Result
                .Contacts
                .Select(c => new ContactViewModel()
                {
                    ContactId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    Email = c.Email,
                    Website = c.Website,
                    PhoneNumber = c.PhoneNumber

                }).ToArray()
            };
            
                
            return View(model);
        }

        //[HttpGet]
        //public IActionResult Add()
        //{

        //}
        //[HttpPost]
        //public IActionResult Add()
        //{

        //}
        //[HttpGet]
        //public IActionResult Edit()
        //{

        //}
        //[HttpPost]
        //public IActionResult Edit()
        //{

        //}


    }
}

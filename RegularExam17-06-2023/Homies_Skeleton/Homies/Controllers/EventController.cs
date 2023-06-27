using Homies.Models.Event;
using Homies.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }
        public async Task<IActionResult> All()
        {
            var model = await eventService.GetAllEventsAsync();
            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await eventService.GetJoinedEventsAsync(userId);
            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool joined = await eventService.EventAlreadyJoinedAsync(id, userId);
            bool exists = await eventService.EventExistsAsync(id);
            bool isOrganiser = await eventService.IsOrganizerAsync(id, userId);

            if(!joined && exists && !isOrganiser)
            {
                await eventService.JoinEvent(id, userId);
                return RedirectToAction("Joined", "Event");
            }

            return RedirectToAction("All", "Event");

            
        }

        public async Task<IActionResult> Leave(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool joined = await eventService.EventAlreadyJoinedAsync(id, userId);
            if (joined)
            {
                await eventService.LeaveEvent(id, userId);
                return RedirectToAction("All", "Event");
            }

            return RedirectToAction("Joined", "Event");
            
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var types = await eventService.GetAllTypesAsync();
            EventFormViewModel model = new EventFormViewModel()
            {
                Types = types
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await eventService.GetAllTypesAsync();
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTime createdOn = DateTime.UtcNow;

            await eventService.CreateEventAsync(model, userId, createdOn);

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var canEdit = await eventService.IsOrganizerAsync(id, userId);
            if (canEdit)
            {
                var model = await eventService.GetForEditAsync(id);
                if(model == null)
                {
                    return RedirectToAction("All", "Event");
                }

                model.Types = await eventService.GetAllTypesAsync();
                return View(model);
            }
            else
            {
                return RedirectToAction("All", "Event");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            await eventService.EditEventAsync(model, id);
            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await eventService.DetailsAsync(id);
            if(model == null)
            {
                return RedirectToAction("All", "Event");
            }

            return View(model);
        }
    }
}

using Homies.Data;
using Homies.Data.Entities;
using Homies.Models.Event;
using Homies.Models.Type;
using Homies.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;
        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task CreateEventAsync(EventFormViewModel model, string organiserId, DateTime createdOn)
        {
            Event newEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = organiserId,
                CreatedOn = createdOn
            };

            await context.Events.AddAsync(newEvent);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventListViewModel>> GetAllEventsAsync()
        {
            var events = await context.Events
                .Select(e => new EventListViewModel()
                {
                    Id = e.Id,
                    Organiser = e.Organiser.UserName,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name

                }).ToArrayAsync();

            return events;
        }

        public async Task<IEnumerable<TypeListViewModel>> GetAllTypesAsync()
        {
            var types = await context.Types
                .Select(t => new TypeListViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToArrayAsync();

            return types;
        }

        public async Task<IEnumerable<EventListViewModel>> GetJoinedEventsAsync(string userId)
        {
            var joinedEvents = await context
                .EventsParticipants
                .Where(e => e.HelperId == userId)
                .Select(e => new EventListViewModel()
                {
                    Id = e.Event.Id,
                    Organiser = e.Event.Organiser.UserName,
                    Name = e.Event.Name,
                    Start = e.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Event.Type.Name
                }).ToArrayAsync();

            return joinedEvents;
        }

        public async Task JoinEvent(int eventId, string userId)
        {

            EventParticipant eventParticipant = new EventParticipant()
            {
                EventId = eventId,
                HelperId = userId
            };
            await context.EventsParticipants.AddAsync(eventParticipant);
            await context.SaveChangesAsync();

        }

        public async Task LeaveEvent(int eventId, string userId)
        {

            EventParticipant eventParticipant = await context
                .EventsParticipants
                .FirstAsync(ep => ep.EventId == eventId && ep.HelperId == userId);

            context.EventsParticipants.Remove(eventParticipant);
            await context.SaveChangesAsync();


        }

        public async Task<bool> EventAlreadyJoinedAsync(int eventId, string userId)
        {
            return await context.EventsParticipants
                .AnyAsync(ep => ep.EventId == eventId && ep.HelperId == userId);
        }

        public async Task<bool> EventExistsAsync(int eventId)
        {
            return await context.Events
                .AnyAsync(e => e.Id == eventId);
        }

        public async Task<bool> IsOrganizerAsync(int eventId, string userId)
        {
            Event? thisEvent = await context.Events
                .FirstOrDefaultAsync(e => e.Id == eventId && e.OrganiserId == userId);

            return thisEvent != null;
        }

        public async Task<EventFormViewModel?> GetForEditAsync(int id)
        {
            var model = await context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventFormViewModel()
                {
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    Description = e.Description,
                    TypeId = e.TypeId
                }).FirstOrDefaultAsync();

            return model;
        }

        public async Task EditEventAsync(EventFormViewModel model, int id)
        {
            var thisEvent = await context.Events
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if(thisEvent != null)
            {
                thisEvent.Name = model.Name;
                thisEvent.Description = model.Description;
                thisEvent.Start = model.Start;
                thisEvent.End = model.End;
                thisEvent.TypeId = model.TypeId;

                await context.SaveChangesAsync();
            }

        }

        public async Task<EventDetailsViewModel?> DetailsAsync(int id)
        {
            var model = await context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                    

                }).FirstOrDefaultAsync();

            return model;
        }
    }
}

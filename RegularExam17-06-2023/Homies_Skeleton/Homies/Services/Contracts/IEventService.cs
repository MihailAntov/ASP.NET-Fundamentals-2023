using Homies.Models.Event;
using Homies.Models.Type;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        public Task<IEnumerable<EventListViewModel>> GetAllEventsAsync();
        public Task<IEnumerable<EventListViewModel>> GetJoinedEventsAsync(string userId);
        public Task<IEnumerable<TypeListViewModel>> GetAllTypesAsync();

        public Task CreateEventAsync(EventFormViewModel model, string organiserId, DateTime createdOn);

        public Task JoinEvent(int eventId, string userId);
        public Task LeaveEvent(int eventId, string userId);

        public Task<bool> EventExistsAsync(int eventId);
        public Task<bool> EventAlreadyJoinedAsync(int eventId, string userId);

        public Task<bool> IsOrganizerAsync(int eventId, string userId);
        public Task<EventFormViewModel?> GetForEditAsync(int id);

        public Task EditEventAsync(EventFormViewModel model, int id);

        public Task<EventDetailsViewModel?> DetailsAsync(int id);

        


    }
}

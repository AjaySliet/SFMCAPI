using GDOT.SFMC.Domain.Models;

namespace GDOT.SFMC.Business.Interfaces
{
    interface ISubscriberService
    {
        Notification ReceivedMessageFromQueue();
    }
}

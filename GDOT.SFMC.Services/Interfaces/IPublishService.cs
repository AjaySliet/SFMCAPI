using GDOT.SFMC.Domain.Models;

namespace GDOT.SFMC.Business.Interfaces
{
    public interface IPublishService
    {
        Notification SendMessageToQueue(Notification notificationRequest);
    }
}

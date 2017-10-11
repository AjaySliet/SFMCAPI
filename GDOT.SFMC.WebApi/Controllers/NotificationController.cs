using GDOT.SFMC.Business.Interfaces;
using GDOT.SFMC.Domain.Models;
using System.Web.Http;

namespace GDOT.SFMC.WebApi
{
    public class NotificationController : ApiController
    {
        private readonly IPublishService _publishService;

        public NotificationController()
        {

        }

        public NotificationController(IPublishService publishService)
        {
            _publishService = publishService;
        }

        [HttpGet]
        public string Index()
        {
            return "Hello World";
        }

        [HttpPost]
        public Notification SendMessageToQueue(Notification notificationRequest)
        {
            return _publishService.SendMessageToQueue(notificationRequest);
        }
    }
}

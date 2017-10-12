using GDOT.SFMC.Business.Interfaces;
using GDOT.SFMC.Domain.Models;
using log4net;
using System.Web.Http;

namespace GDOT.SFMC.WebApi
{
    public class NotificationController : ApiController
    {
        private readonly IPublishService _publishService;
        private readonly ILog _logger;

        public NotificationController()
        {
            
        }

        public NotificationController(IPublishService publishService)
        {
            _publishService = publishService;
            _logger = LogManager.GetLogger(typeof(NotificationController));
        }

        [HttpGet]
        public string Index()
        {
            return "Hello World";
        }

        [HttpPost]
        public Notification SendMessageToQueue(Notification notificationRequest)
        {
            _logger.Info("SendMessageToQueue Request initiated");
            return _publishService.SendMessageToQueue(notificationRequest);
        }
    }
}

using GDOT.SFMC.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GDOT.SFMC.Business.Services
{   
    public class MessageQueueService : IMessageQueueService
    {
        public MessageQueueService()
        {
        }

        public bool Exists(string path)
        {
            return MessageQueue.Exists(path);
        }

        public MessageQueue Create(string path, bool transactional)
        {
            return MessageQueue.Create(path, transactional);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GDOT.SFMC.Business.Interfaces
{
    public interface IMessageQueueService
    {
        bool Exists(string path);
        MessageQueue Create(string path, bool transactional);
    }
}

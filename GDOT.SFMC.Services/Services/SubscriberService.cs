using GDOT.SFMC.Business.Interfaces;
using GDOT.SFMC.Domain.Models;
using System;
using System.Messaging;

namespace GDOT.SFMC.Business.Services
{
    public class SubscriberService : ISubscriberService
    {
        const string queueName = @".\private$\SFMCMessageQueue";

        public Notification ReceivedMessageFromQueue()
        {
            MessageQueue messageQueue = new MessageQueue(queueName);
            Notification message = null;
            try
            {
                messageQueue.Formatter = new BinaryMessageFormatter();

                message = (Notification)messageQueue.Receive().Body;
            }
            catch (MessageQueueException ee)
            {
                //logging
            }

            catch (Exception eee)
            {
                //logging
            }

            finally
            {
                messageQueue.Close();
            }
            return message;
        }
    }
}

using GDOT.SFMC.Domain.Models;
using System;
using System.Messaging;
using GDOT.SFMC.Domain.Enums;
using GDOT.SFMC.Business.Interfaces;

namespace GDOT.SFMC.Business.Services
{
    public class PublishService: IPublishService
    {
        const string queueName = @".\private$\SFMCMessageQueue";

        public Notification SendMessageToQueue(Notification notificationRequest)
        {
            MessageQueue messageQueue = null;

            if (notificationRequest == null && notificationRequest.EventList == null
                && notificationRequest.EventList.Count.Equals(0))
                return notificationRequest;

            messageQueue = MessageQueue.Exists(queueName) ? new MessageQueue(queueName) :
                                                        MessageQueue.Create(queueName, true);

            notificationRequest.EventList.ForEach(x => x.AttributesList.ForEach(
                a => a.Add("ResponseToken", Guid.NewGuid().ToString())));

            try
            {
                messageQueue.Formatter = new BinaryMessageFormatter();
                // Since we're using a transactional queue, make a transaction.
                using (MessageQueueTransaction messageQueueTransaction = new MessageQueueTransaction())
                {
                    messageQueueTransaction.Begin();

                    // Send the message.
                    messageQueue.Send(notificationRequest, messageQueueTransaction);

                    messageQueueTransaction.Commit();
                }
            }
            catch (MessageQueueException ee)
            {
                notificationRequest.Status = Status.Failure;
                // logging
            }
            catch (Exception eee)
            {
                notificationRequest.Status = Status.Failure;
                //logging
            }
            finally
            {
                messageQueue.Close();
            }

            //Code to Send to MSMQ
            return notificationRequest;
        }
    }
}

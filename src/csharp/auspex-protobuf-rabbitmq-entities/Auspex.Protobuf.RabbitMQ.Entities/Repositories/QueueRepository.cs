using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auspex.Protobuf.RabbitMQ.Entities.Repositories
{
    /// <summary>
    /// General rabbitmq queue repository for generic type where T is a Google Protobuf message
    /// </summary>
    /// <typeparam name="MessageType"></typeparam>
    public class QueueRepository<MessageType> : IDisposable where MessageType: class, Google.Protobuf.IMessage
    {
        private readonly EasyNetQ.IBus messageQueueBus;

        public QueueRepository(string hostName)
        {
            messageQueueBus = EasyNetQ.RabbitHutch.CreateBus($"host={hostName}");            
        }

        public void Subscribe(Action<MessageType> action)
        {
            messageQueueBus.Subscribe<MessageType>(typeof(MessageType).Name,
                action
                );
        }

        public void Publish(MessageType message)
        {
            messageQueueBus.Publish(message);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.messageQueueBus.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}

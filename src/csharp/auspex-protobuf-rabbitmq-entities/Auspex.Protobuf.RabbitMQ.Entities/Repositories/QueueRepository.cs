using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auspex.Protobuf.RabbitMQ.Entities.Repositories
{
    /// <summary>
    /// General rabbitmq queue repository for generic type where T is a Google Protobuf message
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueRepository<T> where T: Google.Protobuf.IMessage
    {

    }
}

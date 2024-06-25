using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public interface IRabbitMQRepository
    {
        public Task<string> AddUser(User user);
        public Task<string> CallAsync(string message, CancellationToken cancellationToken = default);
    }
}

using System;
using Confluent.Kafka;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Clients.Application.Contracts.Infrastructure;

namespace Clients.Infrastructure.Publishers
{
    public class AccountPublisher : IAccountPublisher
    {
        private readonly IProducer<int, string> _producer;
        private readonly IConfiguration _configuration;

        public AccountPublisher(IProducer<int, string> producer, IConfiguration configuration)
        {
            _producer = producer ?? throw new ArgumentNullException(nameof(producer));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task SendMessageAsync<T>(T entity)
        {
            var topicName = _configuration.GetValue<string>("TopicName"); // Работает вместе с NuGet "Microsoft.Extensions.Configuration.Binder"
            var message = new Message<int, string>
            {
                Key = 1, // Произвольное значение
                Value = JsonSerializer.Serialize(entity)
            };

            await _producer.ProduceAsync(topicName, message);
        }

    }
}

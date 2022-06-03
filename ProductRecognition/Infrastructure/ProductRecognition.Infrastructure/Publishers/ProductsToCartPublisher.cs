using System;
using Confluent.Kafka;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProductRecognition.Application.Contracts.Infrastructure;
using ProductRecognition.Application.DTOForEvents.ProductRecognized;

namespace ProductRecognition.Infrastructure.Publishers
{
    public class ProductsToCartPublisher : IProductsToCartPublisher
    {
        private readonly IProducer<int, string> _producer;
        private readonly IConfiguration _configuration;

        public ProductsToCartPublisher(IProducer<int, string> producer, IConfiguration configuration)
        {
            _producer = producer ?? throw new ArgumentNullException(nameof(producer));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task SendMessageAsync(ProductsToCartEvent entity)
        {
            var topicName = _configuration.GetValue<string>("TopicNamePTC");
            var message = new Message<int, string>
            {
                Key = 1, // Произвольное значение
                Value = JsonSerializer.Serialize(entity)
            };

            await _producer.ProduceAsync(topicName, message);
        }
    }
}

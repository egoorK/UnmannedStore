using System;
using MediatR;
using Confluent.Kafka;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ProductRecognition.Application.Features.Accounts.Commands.CreateAccount;

namespace ProductRecognition.Infrastructure.Consumers
{
    public class AccountConsumer : BackgroundService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AccountConsumer(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {

            var bootstrapperServer = _configuration.GetValue<string>("BootstrapperServer");
            var consumerGroupId = _configuration.GetValue<string>("ConsumerGroupId");
            var topicName = _configuration.GetValue<string>("TopicName");

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = bootstrapperServer,
                GroupId = consumerGroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false,
                EnableAutoOffsetStore = false
            };

            using (var _consumer = new ConsumerBuilder<int, string>(consumerConfig).Build())
            {
                _consumer.Subscribe(topicName);

                while (!cancellationToken.IsCancellationRequested)  //Значение true, если для токена была запрошена отмена
                {
                    try
                    {
                        var consumerResult = _consumer.Consume(cancellationToken);

                        if (consumerResult == null || consumerResult.IsPartitionEOF)
                        {
                            continue; // Пропускает выполнение оставшегося в цикле кода
                        }
                        
                        var command = JsonSerializer.Deserialize<CreateAccountCommand>(consumerResult.Message.Value);

                        //  отправка данных через медиатора
                        await _mediator.Send(command);

                        _consumer.StoreOffset(consumerResult);
                        _consumer.Commit(consumerResult);

                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Произошло исключение: {e.Error.Reason}");
                    }
                }
                //_consumer.Close();
            }
        }

    }
}

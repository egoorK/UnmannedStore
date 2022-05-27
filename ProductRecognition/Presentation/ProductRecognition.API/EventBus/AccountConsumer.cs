using MediatR;
using MassTransit;
using System;
using System.Threading.Tasks;
using ProductRecognition.Application.Features.Accounts.Commands.CreateAccount;


namespace ProductRecognition.API.EventBus
{
    public class AccountConsumer : IConsumer<CreateAccountCommand>
    {
        private readonly IMediator _mediator;

        public AccountConsumer(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<CreateAccountCommand> command)
        {
            await _mediator.Send(command.Message);
        }
    }
}

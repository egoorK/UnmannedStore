using System;
using MediatR;
using MassTransit;
using System.Threading.Tasks;
using ProductRecognition.Infrastructure.DTOForEvents;
using ProductRecognition.Application.Features.Accounts.Commands.CreateAccount;
using ProductRecognition.Application.Features.Accounts.Commands.UpdateAccount;
using ProductRecognition.Application.Features.Accounts.Commands.DeleteAccount;

namespace ProductRecognition.API.Consumers
{
    public class AccountConsumer : IConsumer<AccountCommandEvent>
    {
        private readonly IMediator _mediator;

        public AccountConsumer(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<AccountCommandEvent> context)
        {
            var ctx = context.Message.Event_Type;

            if (ctx == "created")
            {
                var command = new CreateAccountCommand()
                {
                    Account_ID = context.Message.Account_ID,
                    Username = context.Message.Username
                };
                await _mediator.Send(command);
            }
            else if (ctx == "updated")
            {
                var command = new UpdateAccountCommand()
                {
                    Account_ID = context.Message.Account_ID,
                    Username = context.Message.Username
                };
                await _mediator.Send(command);
            }
            else
            {
                var command = new DeleteAccountCommand()
                {
                    Account_ID = context.Message.Account_ID
                };
                await _mediator.Send(command);
            }
        }
    }
}
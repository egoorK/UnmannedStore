using System;
using MediatR;
using MassTransit;
using System.Threading.Tasks;
using ProductRecognition.Infrastructure.DTOForEvents;
using ProductRecognition.Application.Features.ProductsInImages.Commands.CreateProductInImage;

namespace ProductRecognition.API.Consumers
{
    public class ProductRecognizedConsumer : IConsumer<CreateProductInImageCommand>
    {
        private readonly IMediator _mediator;
        public ProductRecognizedConsumer(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<CreateProductInImageCommand> context)
        {
            var command = context.Message;
            //var ctxProd = context.Message.Products;

            //var command = new CreateProductInImageCommand() 
            //{
            //    Image_ID = context.Message.Image_ID,
            //};

            //for (int i = 0; i < ctxProd.Count; i++)
            //{
            //    command.Products.Add(new Application.DTOForEvents.ProductRecognized.ProductRecognizedEvent() 
            //    { 
            //        Product_ID = ctxProd[i].Product_ID,
            //        Probability_recognition
            //    });

            //!!!ПРОИНИЦИАЛИЗИРОВАТЬ СПИСОК В КОНСТРУКТОРЕ!!!(см.ProductsToCartEvent)

            //    command.Products[i].Product_ID = ctxProd[i].Product_ID;
            //    command.Products[i].Product_frame.Top_Left_Corner_Coord_X = ctxProd[i].Product_frame.Top_Left_Corner_Coord_X;
            //    command.Products[i].Product_frame.Top_Left_Corner_Coord_Y = ctxProd[i].Product_frame.Top_Left_Corner_Coord_Y;
            //    command.Products[i].Product_frame.Frame_Height = ctxProd[i].Product_frame.Frame_Height;
            //    command.Products[i].Product_frame.Frame_Width = ctxProd[i].Product_frame.Frame_Width;
            //    command.Products[i].Probability_recognition = ctxProd[i].Probability_recognition;
            //}

            await _mediator.Send(command);
        }
    }
}

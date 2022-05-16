using MediatR;
using System;

namespace ProductRecognition.Application.Features.Images.Commands.DeleteImage
{
    public class DeleteImageCommand : IRequest
    {
        public Guid Image_ID { get; set; }
    }
}

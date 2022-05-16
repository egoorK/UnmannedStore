using System;
using MediatR;

namespace ProductRecognition.Application.Features.Images.Commands.UpdateImage
{
    public class UpdateImageCommand : IRequest
    {
        public Guid Image_ID { get; set; }
        public string Image_Base64 { get; set; }
        public DateTime Term_of_Receipt { get; set; }
    }
}

using MediatR;
using System;

namespace ProductRecognition.Application.Features.Images.Commands.SaveImage
{
    public class SaveImageCommand : IRequest
    {
        public Guid Account_ID { get; set; }
        public string Image_Base64 { get; set; }
    }
}

using MediatR;
using System;

namespace ProductRecognition.Application.Features.Images.Queries.GetImageById
{
    public class GetImageQuery : IRequest<ImageVm>
    {
        public Guid Image_ID { get; set; }

        public GetImageQuery(Guid Id)
        {
            if (Id != null)
                Image_ID = Id;
            else
                throw new ArgumentNullException(nameof(Id));
        }
    }
}

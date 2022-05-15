using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Application.Features.Images.Queries.GetImageById
{
    public class GetImageQueryHandler : IRequestHandler<GetImageQuery, ImageVm>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;

        public GetImageQueryHandler(IMapper mapper, IImageRepository imageRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
        }

        public async Task<ImageVm> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetImageByIdAsync(request.Image_ID);
            return _mapper.Map<ImageVm>(image);
        }
    }
}

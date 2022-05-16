using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Application.Features.Images.Commands.UpdateImage
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        //private readonly IImagePublisher _imagePublisher;

        public UpdateImageCommandHandler(IMapper mapper, IImageRepository imageRepository)// IAccountPublisher accountPublisher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
            //_accountPublisher = accountPublisher ?? throw new ArgumentNullException(nameof(accountPublisher));
        }

        public async Task<Unit> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            var imageToUpdate = _mapper.Map<Image>(request);
            await _imageRepository.UpdateAsync(imageToUpdate);

            // Produce

            return Unit.Value;
        }
    }
}

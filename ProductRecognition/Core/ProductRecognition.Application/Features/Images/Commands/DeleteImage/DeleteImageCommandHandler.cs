using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Application.Features.Images.Commands.DeleteImage
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        //private readonly IImagePublisher _imagePublisher;

        public DeleteImageCommandHandler(IMapper mapper, IImageRepository imageRepository)// IAccountPublisher accountPublisher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
            //_accountPublisher = accountPublisher ?? throw new ArgumentNullException(nameof(accountPublisher));
        }

        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var imageToDelete = _mapper.Map<Image>(request);
            await _imageRepository.DeleteAsync(imageToDelete.Image_ID);

            // Produce

            return Unit.Value;
        }
    }
}

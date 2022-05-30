using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.DTOForEvents;
using ProductRecognition.Application.Contracts.Persistence;
using ProductRecognition.Application.Contracts.Infrastructure;

namespace ProductRecognition.Application.Features.Images.Commands.SaveImage
{
    public class SaveImageCommandHandler : IRequestHandler<SaveImageCommand>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly IImagePublisher _imagePublisher;

        public SaveImageCommandHandler(IMapper mapper, IImageRepository imageRepository, IImagePublisher imagePublisher)// IAccountPublisher accountPublisher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
            _imagePublisher = imagePublisher ?? throw new ArgumentNullException(nameof(imagePublisher));
        }

        public async Task<Unit> Handle(SaveImageCommand request, CancellationToken cancellationToken)
        {
            var imageToSave = _mapper.Map<Image>(request);
            var newImageId = await _imageRepository.SaveAsync(imageToSave);

            // Produce
            var imageEventEntity = _mapper.Map<ImageRecognizeEvent>(request);
            imageEventEntity.Image_ID = newImageId;
            await _imagePublisher.SendMessageAsync(imageEventEntity);

            return Unit.Value;
        }
    }
}

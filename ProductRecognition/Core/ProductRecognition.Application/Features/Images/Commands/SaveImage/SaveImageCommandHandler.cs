using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Application.Features.Images.Commands.SaveImage
{
    public class SaveImageCommandHandler : IRequestHandler<SaveImageCommand>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        //private readonly IImagePublisher _imagePublisher;

        public SaveImageCommandHandler(IMapper mapper, IImageRepository imageRepository)// IAccountPublisher accountPublisher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
            //_accountPublisher = accountPublisher ?? throw new ArgumentNullException(nameof(accountPublisher));
        }

        public async Task<Unit> Handle(SaveImageCommand request, CancellationToken cancellationToken)
        {
            var imageToSave = _mapper.Map<Image>(request);
            imageToSave.Term_of_Receipt = DateTime.Now;
            var newImageId = await _imageRepository.SaveAsync(imageToSave);

            // Produce

            return Unit.Value;
        }
    }
}

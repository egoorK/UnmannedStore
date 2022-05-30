using System.Threading.Tasks;
using ProductRecognition.Application.DTOForEvents;

namespace ProductRecognition.Application.Contracts.Infrastructure
{
    public interface IImagePublisher
    {
        Task SendMessageAsync(ImageRecognizeEvent entity);
    }
}

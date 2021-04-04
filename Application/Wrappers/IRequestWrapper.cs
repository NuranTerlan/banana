using MediatR;

namespace Application.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<Response<T>>
    {
        
    }
}
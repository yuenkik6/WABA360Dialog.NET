using System.Net.Http;

namespace WABA360Dialog.Common.Interfaces
{
    internal interface IRequest<TResponse>
    {
        HttpMethod Method { get; }

        string MethodName { get; }
        
        HttpContent ToHttpContent();
    }
}

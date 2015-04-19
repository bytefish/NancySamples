using Nancy;

namespace RestSample.Server.Infrastructure.Web
{
    public interface IHasHttpServiceError
    {
        HttpServiceError HttpServiceError { get; }
    }
}
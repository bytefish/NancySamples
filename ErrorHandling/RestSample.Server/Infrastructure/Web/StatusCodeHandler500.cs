using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses.Negotiation;

namespace RestSample.Server.Infrastructure.Web
{
    public class StatusCodeHandler500 : IStatusCodeHandler
    {
        private IResponseNegotiator responseNegotiator;

        public StatusCodeHandler500(IResponseNegotiator responseNegotiator)
        {
            this.responseNegotiator = responseNegotiator;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.InternalServerError;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            context.NegotiationContext = new NegotiationContext();

            Negotiator negotiator = new Negotiator(context)
                .WithStatusCode(HttpServiceErrorDefinition.InternalServerError.HttpStatusCode)
                .WithModel(HttpServiceErrorDefinition.InternalServerError.HttpStatusCode);

            context.Response = responseNegotiator.NegotiateResponse(negotiator, context);
        }
    }
}
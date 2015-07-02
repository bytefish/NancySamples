using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using Nancy.TinyIoc;

namespace ConnectR
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly TinyIoCContainer container;

        public Bootstrapper(TinyIoCContainer container)
        {
            this.container = container;
        }

        protected override TinyIoCContainer GetApplicationContainer()
        {
            return container;
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(config =>
                {
                    config.ResponseProcessors = new[] { typeof(JsonProcessor), typeof(XmlProcessor) };
                });
            }
        }
        
    }
}

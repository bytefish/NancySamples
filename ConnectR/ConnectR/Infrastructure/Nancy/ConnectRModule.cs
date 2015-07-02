
using Nancy;

namespace ConnectR.Infrastructure.Nancy
{
    public class ConnectRModule : NancyModule
    {
        public ConnectRModule()
            : base()
        {
        }

        public ConnectRModule(string modulePath)
            : base(modulePath)
        {
        }
    }
}

using Nancy;
using System.Linq;

namespace RestSample.Server.Infrastructure.Web.Extensions
{
    /// <summary>
    /// Great extension method from:
    ///
    ///     https://github.com/davidwhitney/NancyApiBuildingGuidance
    /// 
    /// All credit goes to David Whitney.
    /// 
    /// Usage:
    /// 
    ///     Get["/"] = param => Response.AsJson(new { hello = "world v-unknown" });
    ///     Get["/", c => c.ForVersion("1")] = param => Response.AsJson(new { hello = "world v1" });
    ///     Get["/", c => c.ForVersion("2")] = param => Response.AsJson(new { hello = "world v2" });
    /// </summary>
    public static class VersionContaraintExtensions
    {
        private const string VersionHeader = "x-api-version";

        public static bool ForVersion(this NancyContext c, string requiredVersion)
        {
            if (!c.Request.Headers.Keys.Contains(VersionHeader))
            {
                return false;
            }

            return c.Request.Headers[VersionHeader].First() == requiredVersion;
        }
    }
}
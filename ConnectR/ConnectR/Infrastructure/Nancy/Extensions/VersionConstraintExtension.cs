// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectR.Infrastructure.Nancy.Extensions
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
    /// 
    /// </summary>
    public static class VersionConstraintExtensions
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

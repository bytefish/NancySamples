// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNet.SignalR;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectR.Infrastructure.SignalR
{
    internal class TinyDependencyResolver : DefaultDependencyResolver
    {
        private readonly TinyIoCContainer container;

        public TinyDependencyResolver(TinyIoCContainer container)
        {
            this.container = container;
        }

        public override object GetService(Type serviceType)
        {
            if(container.CanResolve(serviceType))
            {
                return container.Resolve(serviceType);
            }
            return base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            if(container.CanResolve(serviceType))
            {
                return container.ResolveAll(serviceType).Concat(base.GetServices(serviceType));
            }
            return base.GetServices(serviceType);
        }
    }
}

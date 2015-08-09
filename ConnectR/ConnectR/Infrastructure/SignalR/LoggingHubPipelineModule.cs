// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using log4net;
using Microsoft.AspNet.SignalR.Hubs;
using System.Reflection;

namespace ConnectR.Infrastructure.SignalR
{
    public class LoggingHubPipelineModule : HubPipelineModule
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            if (log.IsDebugEnabled)
            {
                log.DebugFormat(string.Format("Invoking {0} on hub {1}", context.MethodDescriptor.Name, context.MethodDescriptor.Hub.Name));
            }
            return base.OnBeforeIncoming(context);
        }

        protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
        {
            if (log.IsDebugEnabled)
            {
                log.DebugFormat(string.Format("Invoking {0} on client hub {1}", context.Invocation.Method, context.Invocation.Hub));
            }
            return base.OnBeforeOutgoing(context);
        }

        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext context)
        {
            if (log.IsErrorEnabled)
            {
                log.ErrorFormat("Exception while invoking {0} on hub {1}: {2}", context.MethodDescriptor.Name, context.MethodDescriptor.Hub.Name, exceptionContext.Error.Message);
            }
            base.OnIncomingError(exceptionContext, context);
        }
    }
}

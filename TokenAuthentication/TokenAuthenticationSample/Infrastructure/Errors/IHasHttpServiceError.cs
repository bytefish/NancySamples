// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;

namespace RestSample.Server.Infrastructure.Errors
{
    public interface IHasHttpServiceError
    {
        HttpServiceError HttpServiceError { get; }
    }
}
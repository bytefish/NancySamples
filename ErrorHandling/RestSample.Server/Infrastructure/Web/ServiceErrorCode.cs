// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace RestSample.Server.Infrastructure.Web
{
    public enum ServiceErrorCode
    {
        [XmlEnum("0")]
        GeneralError = 0,

        [XmlEnum("10")]
        NotFound = 10,

        [XmlEnum("20")]
        InternalServerError = 20,

        [XmlEnum("30")]
        InvalidToken = 30,
    }
}
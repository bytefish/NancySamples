// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace RestSample.Server.Infrastructure.Errors
{
    public enum ServiceErrorCode
    {
        [XmlEnum("0")]
        GeneralError = 0,

        [XmlEnum("1")]
        ValidationError = 1,

        [XmlEnum("10")]
        NotFound = 10,

        [XmlEnum("20")]
        InternalServerError = 20,

        [XmlEnum("30")]
        Unauthorized = 30,

        [XmlEnum("31")]
        InvalidToken = 31,
        
    }
}
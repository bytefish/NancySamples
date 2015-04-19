using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
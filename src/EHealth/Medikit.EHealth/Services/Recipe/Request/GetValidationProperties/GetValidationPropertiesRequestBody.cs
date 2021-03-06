﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Medikit.EHealth.SOAP;
using Medikit.EHealth.SOAP.DTOs;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Medikit.EHealth.Services.Recipe.Request
{
    public class GetValidationPropertiesRequestBody : SOAPBody
    {
        [XmlElement(ElementName = "GetValidationPropertiesRequest", Namespace = Constants.Namespaces.RECIPE)]
        public GetValidationPropertiesRequest Request { get; set; }

        public override XElement Serialize()
        {
            var result = new XElement(Constants.XMLNamespaces.SOAPENV + "Body",
                new XAttribute(XNamespace.Xmlns + "wsu", Constants.XMLNamespaces.WSU),
                new XAttribute(Constants.XMLNamespaces.WSU + "Id", Id));
            if (Request != null)
            {
                result.Add(Request.Serialize());
            }

            return result;
        }
    }
}

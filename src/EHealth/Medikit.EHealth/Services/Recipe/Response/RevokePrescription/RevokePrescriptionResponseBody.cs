﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Medikit.EHealth.SOAP.DTOs;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Medikit.EHealth.Services.Recipe.Response
{
    public class RevokePrescriptionResponseBody : SOAPBody
    {

        [XmlElement("RevokePrescriptionResponse", Namespace = Constants.Namespaces.RECIPE)]
        public RevokePrescriptionResponse RevokePrescriptionResponse { get; set; }

        public override XElement Serialize()
        {
            throw new System.NotImplementedException();
        }
    }
}

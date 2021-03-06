﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Medikit.EHealth.EHealthServices.Results
{
    public class DmppResult
    {
        public string DeliveryEnvironment { get; set; }
        public string CodeType { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public bool Reimbursable { get; set; }
    }
}

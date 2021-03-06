// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security.Cryptography.X509Certificates;

namespace Medikit.Security.Cryptography.Asn1
{
    public partial struct X509ExtensionAsn
    {
        public X509ExtensionAsn(X509Extension extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            ExtnId = extension.Oid!;
            Critical = extension.Critical;
            ExtnValue = extension.RawData;
        }
    }
}

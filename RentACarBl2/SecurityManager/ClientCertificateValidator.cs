using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManager
{
    public class ClientCertificateValidator : X509CertificateValidator
    {

        public override void Validate(X509Certificate2 certificate)
        {
            throw new NotImplementedException();
        }
    }
}

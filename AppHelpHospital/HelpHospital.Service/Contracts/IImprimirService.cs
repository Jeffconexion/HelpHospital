using HelpHospital.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpHospital.Service.Contracts
{
    public interface IImprimirService
    {
        string GerarPdf(PacienteDomain valor);
    }
}

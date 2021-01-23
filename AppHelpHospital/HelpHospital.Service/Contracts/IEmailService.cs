using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpHospital.Service.Contracts
{
    public interface IEmailService
    {
        void Enviar(string to, string body);
    }
}

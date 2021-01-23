using System.Collections.Generic;

namespace HelpHospital.Domain
{
    public class MedicoDomain
    {

        public MedicoDomain()
        {
            this.Pacientes = new List<PacienteDomain>();
        }
        public int IdMedico { set; get; }
        public string Nome { set; get; }
        public string SobreNome { set; get; }
        public string Especializacao { set; get; }
        public string Crm { set; get; }
        public ICollection<PacienteDomain> Pacientes { set; get; }
    }
}

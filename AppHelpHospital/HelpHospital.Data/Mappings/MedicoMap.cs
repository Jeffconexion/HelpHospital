using HelpHospital.Domain;
using System.Data.Entity.ModelConfiguration;

namespace HelpHospital.Data.Mappings
{
    public class MedicoMap : EntityTypeConfiguration<MedicoDomain>
    {

        public MedicoMap()
        {
            ToTable("tb_medico");
            HasKey(m => m.IdMedico);

            Property(m => m.Nome).HasMaxLength(40).IsRequired();
            Property(m => m.SobreNome).HasMaxLength(40).IsRequired();
            Property(m => m.Especializacao).HasMaxLength(40);
            Property(m => m.Crm).HasMaxLength(40).IsRequired();
            
        }

    }
}

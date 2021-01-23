using HelpHospital.Domain;
using System.Data.Entity.ModelConfiguration;

namespace HelpHospital.Data.Mappings
{
    public class AtendenteMap : EntityTypeConfiguration<AtendenteDomain>
    {

        public AtendenteMap()
        {
            ToTable("tb_atendente");
            HasKey(a => a.IdAtendente);

            Property(a => a.Rg).HasMaxLength(30).IsRequired();
            Property(a => a.Nome).HasMaxLength(40).IsRequired();
            Property(a => a.SobreNome).HasMaxLength(40).IsRequired();

        }
    }
}

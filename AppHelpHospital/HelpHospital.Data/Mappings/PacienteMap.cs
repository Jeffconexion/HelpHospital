using HelpHospital.Domain;
using System.Data.Entity.ModelConfiguration;

namespace HelpHospital.Data.Mappings
{
    public class PacienteMap : EntityTypeConfiguration<PacienteDomain>
    {

        public PacienteMap()
        {
            ToTable("tb_paciente");
            HasKey(p => p.IdPaciente);

            Property(p => p.Rg);
            Property(p => p.NomePaciente).HasMaxLength(40).IsRequired();
            Property(p => p.SobreNomePaciente).HasMaxLength(40).IsRequired();
            Property(p => p.DataNascimento).IsRequired();
            Property(p => p.Sexo).HasMaxLength(10);            
            Property(p => p.Estado).HasMaxLength(40).IsRequired();
            Property(p => p.Cidade).HasMaxLength(40).IsRequired();
            Property(p => p.Rua).HasMaxLength(40).IsRequired();
            Property(p => p.NumeroDaCasa).HasMaxLength(10).IsRequired();
            Property(p => p.Telefone).HasMaxLength(20).IsRequired();
            Property(p => p.Alergia).HasMaxLength(40).IsOptional();
            Property(p => p.Queixa).HasMaxLength(300).IsOptional();
            Property(p => p.NomeCuidador).HasMaxLength(40).IsRequired();
            Property(p => p.EmailCuidador).HasMaxLength(50).IsRequired();
            Property(p => p.MensagemParaCuidador).HasMaxLength(400).IsRequired();
            Property(p => p.DoencaAtual).HasMaxLength(400).IsOptional();
            Property(p => p.DataDeCadastro).IsOptional();
            Property(p => p.DataDeSaida).IsOptional();

            HasMany(p => p.Medicos)
                .WithMany(m => m.Pacientes)
                .Map(m => m.ToTable("tb_paciente_medico"));
        }



    }
}

using HelpHospital.Data.Mappings;
using HelpHospital.Domain;
using System.Data.Entity;

namespace HelpHospital.Data.Context
{
    public class HelpHospitalDb : DbContext
    {
        public HelpHospitalDb() : base("DefaultConnection")
        {

        }

        public DbSet<PacienteDomain> Pacientes { set; get; }
        public DbSet<MedicoDomain> Medicos { set; get; }
        public DbSet<AtendenteDomain> Atendente { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PacienteMap());
            modelBuilder.Configurations.Add(new MedicoMap());
            modelBuilder.Configurations.Add(new AtendenteMap());

        }

    }
}

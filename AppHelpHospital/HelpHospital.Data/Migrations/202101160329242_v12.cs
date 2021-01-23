namespace AppHelpHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_atendente",
                c => new
                    {
                        IdAtendente = c.Int(nullable: false, identity: true),
                        Rg = c.String(nullable: false, maxLength: 30),
                        Nome = c.String(nullable: false, maxLength: 40),
                        SobreNome = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.IdAtendente);
            
            CreateTable(
                "dbo.tb_medico",
                c => new
                    {
                        IdMedico = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                        SobreNome = c.String(nullable: false, maxLength: 40),
                        Especializacao = c.String(maxLength: 40),
                        Crm = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.IdMedico);
            
            CreateTable(
                "dbo.tb_paciente",
                c => new
                    {
                        IdPaciente = c.Int(nullable: false, identity: true),
                        Rg = c.Int(nullable: false),
                        NomePaciente = c.String(nullable: false, maxLength: 40),
                        SobreNomePaciente = c.String(nullable: false, maxLength: 40),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 10),
                        Estado = c.String(nullable: false, maxLength: 40),
                        Cidade = c.String(nullable: false, maxLength: 40),
                        Rua = c.String(nullable: false, maxLength: 40),
                        NumeroDaCasa = c.String(nullable: false, maxLength: 10),
                        Telefone = c.String(nullable: false, maxLength: 20),
                        Alergia = c.String(maxLength: 40),
                        Queixa = c.String(maxLength: 300),
                        NomeCuidador = c.String(nullable: false, maxLength: 40),
                        EmailCuidador = c.String(nullable: false, maxLength: 50),
                        MensagemParaCuidador = c.String(nullable: false, maxLength: 400),
                        DoencaAtual = c.String(maxLength: 400),
                        DataDeCadastro = c.DateTime(),
                        DataDeSaida = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPaciente);
            
            CreateTable(
                "dbo.tb_paciente_medico",
                c => new
                    {
                        PacienteDomain_IdPaciente = c.Int(nullable: false),
                        MedicoDomain_IdMedico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PacienteDomain_IdPaciente, t.MedicoDomain_IdMedico })
                .ForeignKey("dbo.tb_paciente", t => t.PacienteDomain_IdPaciente, cascadeDelete: true)
                .ForeignKey("dbo.tb_medico", t => t.MedicoDomain_IdMedico, cascadeDelete: true)
                .Index(t => t.PacienteDomain_IdPaciente)
                .Index(t => t.MedicoDomain_IdMedico);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_paciente_medico", "MedicoDomain_IdMedico", "dbo.tb_medico");
            DropForeignKey("dbo.tb_paciente_medico", "PacienteDomain_IdPaciente", "dbo.tb_paciente");
            DropIndex("dbo.tb_paciente_medico", new[] { "MedicoDomain_IdMedico" });
            DropIndex("dbo.tb_paciente_medico", new[] { "PacienteDomain_IdPaciente" });
            DropTable("dbo.tb_paciente_medico");
            DropTable("dbo.tb_paciente");
            DropTable("dbo.tb_medico");
            DropTable("dbo.tb_atendente");
        }
    }
}

using HelpHospital.Domain;
using System;
using System.Collections.Generic;

namespace HelpHospital.Service.Contracts
{
    public interface IPacienteService : IDisposable
    {
        List<PacienteDomain> ObterTodosPacientes();
        PacienteDomain ObterPacientePorId(int id);
        PacienteDomain ObterPacientePorRg(int rg);
        List<PacienteDomain> ObterPacientePorNome(string nome, string sobreNome);
        bool CadastrarNovoPaciente(PacienteDomain paciente);
        bool AtualizarPaciente(PacienteDomain paciente);
        void ExcluirPaciente(int id);

    }
}

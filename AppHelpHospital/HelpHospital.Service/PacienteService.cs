using HelpHospital.Data.Context;
using HelpHospital.Domain;
using HelpHospital.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HelpHospital.Service
{
    public class PacienteService : IPacienteService
    {
        private HelpHospitalDb _banco;
        public PacienteService(HelpHospitalDb banco)
        {
            _banco = banco;
        }

        public bool AtualizarPaciente(PacienteDomain paciente)
        {
            _banco.Entry(paciente).State = EntityState.Modified;
            _banco.SaveChanges();
            return true;
        }

        public bool CadastrarNovoPaciente(PacienteDomain paciente)
        {
            paciente.DataDeCadastro = DateTime.Now;
            paciente.DataDeSaida = null;

            IQueryable<PacienteDomain> pacienteExiste = _banco.Pacientes.Where(p => p.Rg == paciente.Rg);

            foreach (var pacienteLocalizado in pacienteExiste)
            {
                if (pacienteLocalizado.DataDeSaida == null)
                {
                    return false;
                }
            }

           //enviar e-mail
            _banco.Pacientes.Add(paciente);
            _banco.SaveChanges();
            return true;
        }

        public void ExcluirPaciente(int id)
        {
            var pacienteExiste = _banco.Pacientes.Find(id);

            if (!ENuloRegistro(pacienteExiste))
            {
                pacienteExiste.DataDeSaida = DateTime.Now;

                _banco.Entry<PacienteDomain>(pacienteExiste).State = EntityState.Modified;

                _banco.SaveChanges();
            }

        }

        public PacienteDomain ObterPacientePorId(int id)
        {
            return _banco.Pacientes.Find(id);
        }

        public List<PacienteDomain> ObterPacientePorNome(string nome, string sobreNome)
        {
            return _banco.Pacientes.Where(p => p.NomePaciente.Contains(nome) && p.SobreNomePaciente.Contains(sobreNome)).ToList();
        }

        public List<PacienteDomain> ObterTodosPacientes()
        {
            return _banco.Pacientes
                    .Where(p => p.DataDeSaida == null)
                    .ToList();
        }

        public void Dispose()
        {
            _banco.Dispose();
        }

        //Outros métodos Utilitários.
        private static bool ENuloRegistro(object pacienteExiste)
        {
            return pacienteExiste == null;
        }

        public PacienteDomain ObterPacientePorRg(int rg)
        {
            return _banco.Pacientes.Where(p => p.Rg == rg && p.DataDeSaida == null).SingleOrDefault();
        }
    }
}

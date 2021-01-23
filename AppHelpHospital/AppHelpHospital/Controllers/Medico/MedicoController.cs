using HelpHospital.Domain;
using HelpHospital.Service.Contracts;
using System.Web.Mvc;

namespace AppHelpHospital.Controllers.Medico
{
    [RoutePrefix("Medico")]
    public class MedicoController : Controller
    {

        private IPacienteService _paciente;
        private IImprimirService _imprimir;

        public MedicoController(IPacienteService paciente, IImprimirService imprimir)
        {
            _paciente = paciente;
            _imprimir = imprimir;
        }

        [HttpGet]
        public ActionResult Prontuario()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Prontuario")]
        public ActionResult ProtuarioCadastro(PacienteDomain paciente)
        {

            var pacienteProtuario = _paciente.ObterPacientePorRg(paciente.Rg);

            if (pacienteProtuario == null)
                TempData["Mensagem"] = "Paciente não está cadastrado no Sistema!";

            return View(pacienteProtuario);
        }

        [HttpGet]
        [Route("editar-paciente/{id:int}")]
        public ActionResult Editar(int id)
        {
            var foiCadastrado = _paciente.ObterPacientePorId(id);

            if (LocalizarCadastro(foiCadastrado))
                return View(foiCadastrado);

            return HttpNotFound();
        }

        [HttpPost]
        [ActionName("Editar")]
        [Route("editar-paciente/{id:int}")]
        public ActionResult EditarPaciente(int id, PacienteDomain paciente)
        {
            if (ValidarEntradaDeDados())
            {
                paciente.IdPaciente = id;
                _paciente.AtualizarPaciente(paciente);

                TempData["medicoPacienteAlterado"] = "Paciente alterado com sucesso!";

                return RedirectToAction("Prontuario", "Medico");
            }
            return View(paciente);
        }

        [HttpGet]
        [Route("detalhes-paciente/{id:int}")]
        public ActionResult Detalhes(int id)
        {
            var foiCadastrado = _paciente.ObterPacientePorId(id);

            if (LocalizarCadastro(foiCadastrado))
                return View(foiCadastrado);

            return HttpNotFound();
        }

        [HttpGet]
        [Route("relatorio-paciente/{id:int}")]
        public ActionResult GerarRelatorio(int id)
        {
            var paciente = _paciente.ObterPacientePorId(id);
            return Redirect(_imprimir.GerarPdf(paciente));
        }

        private static bool LocalizarCadastro(PacienteDomain foiCadastrado)
        {
            return foiCadastrado != null;
        }
        private bool ValidarEntradaDeDados()
        {
            return ModelState.IsValid;
        }

    }
}
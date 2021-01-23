using HelpHospital.Domain;
using HelpHospital.Service.Contracts;
using System.Web.Mvc;

namespace AppHelpHospital.Controllers.Paciente
{
    [RoutePrefix("Paciente")]
    public class PacienteController : Controller
    {
        private IPacienteService _paciente;
        private IEmailService _email;

        public PacienteController(IPacienteService paciente, IEmailService email)
        {
            _paciente = paciente;
            _email = email;
        }

        [Route("listar-paciente")]
        public ActionResult Index()
        {
            return View(_paciente.ObterTodosPacientes());
        }

        [Route("novo-paciente")]
        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [Route("novo-paciente")]
        [HttpPost]
        [ActionName("Criar")]
        public ActionResult CriarCadastro(PacienteDomain paciente)
        {
            
            if (ValidarEntradaDeDados())
            {
                var foiCadastrado = _paciente.CadastrarNovoPaciente(paciente);

                if (foiCadastrado)
                {
                    TempData["Mensagem"] = "Paciente cadastrado com sucesso!";

                    _email.Enviar(paciente.EmailCuidador, paciente.MensagemParaCuidador);
                    return RedirectToAction("Index");
                }
            }
            return View(paciente);
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

                TempData["Mensagem"] = "Paciente alterado com sucesso!";

                _email.Enviar(paciente.EmailCuidador, paciente.MensagemParaCuidador);

                return RedirectToAction("Index");
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
        [Route("excluir-paciente/{id:int}")]
        public ActionResult Deletar(int id)
        {
            var foiCadastrado = _paciente.ObterPacientePorId(id);

            if (LocalizarCadastro(foiCadastrado))
                return View(foiCadastrado);

            return HttpNotFound();

        }

        [HttpPost]
        [Route("excluir-paciente/{id:int}")]
        [ActionName("Deletar")]
        public ActionResult DeletarConfirmar(int id)
        {
            _paciente.ExcluirPaciente(id);

            TempData["Mensagem"] = "Paciente Deletado.";
            return RedirectToAction("Index");
        }

        private bool ValidarEntradaDeDados()
        {
            return ModelState.IsValid;
        }
        private static bool LocalizarCadastro(PacienteDomain foiCadastrado)
        {
            return foiCadastrado != null;
        }
    }
}
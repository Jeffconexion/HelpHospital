using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpHospital.Domain
{
    public class PacienteDomain
    {
        public PacienteDomain()
        {
            this.Medicos = new List<MedicoDomain>();
        }
        public int IdPaciente { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public int Rg { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "Nome")]
        [MaxLength(40)]
        public string NomePaciente { set; get; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [MaxLength(40)]
        public string SobreNomePaciente { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public string Sexo { set; get; }              

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "Estado")]
        public string Estado { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "Cidade")]
        public string Cidade { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "Rua")]
        public string Rua { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "Nº")]
        public string NumeroDaCasa { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public string Telefone { set; get; }

        public string Alergia { set; get; }

        public string Queixa { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "Nome do Responsável")]
        public string NomeCuidador { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "E-mail do Responsável")]
        public string EmailCuidador { set; get; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [Display(Name = "Mensagem para Cuidador")]
        public string MensagemParaCuidador { set; get; }

        [Display(Name = "Doença Atual")]
        public string DoencaAtual { set; get; }

        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataDeCadastro { set; get; }

        [Display(Name = "Data de Saída")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataDeSaida { set; get; }

        public ICollection<MedicoDomain> Medicos { set; get; }
    }
}

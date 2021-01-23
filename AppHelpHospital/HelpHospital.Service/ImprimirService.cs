using HelpHospital.Domain;
using HelpHospital.Service.Contracts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace HelpHospital.Service
{
    public class ImprimirService : IImprimirService
    {
        public string GerarPdf(PacienteDomain paciente)
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            string caminho = AppDomain.CurrentDomain.BaseDirectory + @"\pdf\" + "relatorio.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 25);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Relatório do Paciente\n\n\n\n");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));
            Paragraph paragrafo2 = new Paragraph("", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));

            string conteudo = " Paciente "+paciente.NomePaciente+ " "+paciente.SobreNomePaciente+" "+ 
                "deu entrado no Hospital na data: "+paciente.DataDeCadastro+"."+""+"Foi empregado todos os recursos " +
                "necessáris para seu tratamento.\n\n\n\n";

            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table = new PdfPTable(4);

            table.AddCell("Nome");
            table.AddCell("Alergia");
            table.AddCell("Queixa");
            table.AddCell("Diagnóstico");

            table.AddCell(paciente.NomePaciente+" "+paciente.SobreNomePaciente);
            table.AddCell(paciente.Alergia);
            table.AddCell(paciente.Queixa);
            table.AddCell(paciente.DoencaAtual);

            doc.Add(table);

             string conteudo2 = "\n\n\n\n\n\n\n\n\n\n\n\n Assinatura do Paciente: __________________________________________________";

            paragrafo2.Add(conteudo2);
            doc.Add(paragrafo2);
            
            doc.Close();

            return "/pdf/relatorio.pdf";
        }
    }
}

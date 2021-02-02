using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using ProjekatStudentskiDom.DAO;
using ProjekatStudentskiDom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.ToPDF
{
    class IzvestajPDF
    {
        public static void DodajDokument()
        {
            Document document = new Document();
            Section section = document.AddSection();

            List<Soba> sveSobe = SobaDAO.GetAll(Program.conn);

            foreach (var soba in sveSobe)
            {
                section.AddParagraph(soba.ToString());
            }
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false);
            pdfRenderer.Document = document;

            pdfRenderer.RenderDocument();

            string fileName = "IzvestajSvihSobaUSistemu.pdf";
            pdfRenderer.Save(fileName);

            Process.Start(fileName);
        }
    }
}

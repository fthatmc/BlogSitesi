using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class PdfCvController : Controller
    {
        // GET: PdfCv
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult StaticPdfReport()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "~/BlogSitesi/pdfreports/" + "dosya1.pdf");
			
			var stream = new FileStream(path, FileMode.Create);

			Document document = new Document(PageSize.A4);
			PdfWriter.GetInstance(document, stream);

			document.Open();

			Paragraph paragraph = new Paragraph("CV");

			document.Add(paragraph);
			document.Close();
			return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
		}
	}
}
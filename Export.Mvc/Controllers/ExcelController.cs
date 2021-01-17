using System.Collections.Generic;
using System.Web.Mvc;
using Export.Common.Dto;
using Export.Common.Utils;
using Export.Mvc.Extensions.ActionResults;

namespace Export.Mvc.Controllers
{
    public class ExcelController : Controller
    {
        private const string NombreFichero = "PruebaExcel";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExcelClaseDinamica()
        {
            var listaPersonas = new[] {
                new { Name="Jhonn", Age=32, Email="Jhonn@aaa.com" },
                new { Name="David", Age=33, Email="David@aaa.com" },
                new { Name="Daniel", Age=34, Email="Daniel@aaa.com" },
                new { Name="Gabriella", Age=35, Email="Gabriella@aaa.com" },
                new { Name="Katheryn", Age=36, Email="Katheryn@aaa.com" }
            };

            //TODO: ExcelGenerator debería ser creado con inyección de dependencias
            return new ExcelResult("test", listaPersonas, new ExcelGenerator());
        }

        public ActionResult ExcelListaTipada()
        {
            IList<PersonaDto> listaPersonas = new List<PersonaDto>();
            PersonaDto persona1 = new PersonaDto("Eduardo", "Goikoa", "Pérez", 34);
            PersonaDto persona2 = new PersonaDto("Amaia", "Goikoa", "Pérez", 45);
            PersonaDto persona3 = new PersonaDto("Arantza", "Asiain", "Muniain", 45);
            listaPersonas.Add(persona1);
            listaPersonas.Add(persona2);
            listaPersonas.Add(persona3);

            //TODO: ExcelGenerator debería ser creado con inyección de dependencias
            return new ExcelResult("test", listaPersonas, new ExcelGenerator());
        }
    }
}
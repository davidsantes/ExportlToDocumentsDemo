using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Export.Common.Utils;

namespace Export.Mvc.Extensions.ActionResults
{
    public class ExcelResult : ActionResult
    {
        public string NombreFichero { get; set; }
        public IEnumerable<object> Lista { get; set; }
        public IExcelGenerator _excelGenerator { get; set;  }

        public ExcelResult(string nombreFichero, IEnumerable<object> lista, IExcelGenerator excelGenerator)
        {
            NombreFichero = nombreFichero;
            Lista = lista;
            _excelGenerator = excelGenerator;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (Lista == null || !Lista.Any())
                return;

            var response = context.HttpContext.Response;
            response.ContentType =
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", "attachment;filename=" + NombreFichero + ".xlsx");

            _excelGenerator.CreateExcelFile(NombreFichero, Lista);

            using (var stream = _excelGenerator.CreateExcelFile(NombreFichero, Lista))
            {
                stream.WriteTo(response.OutputStream);
            }
        }
    }
}
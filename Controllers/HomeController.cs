using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Diagnostics;
using TratamentoDados;

namespace WebApp_CEP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string nrCEP = Request.Query["nrCEP"];
            var cep = new DadosCEP();

            if (nrCEP != null)
            {
                cep = ConsultaCEP(nrCEP);
            }

            ViewBag.dadosCEP = cep;
            return View();
        }

        public static DadosCEP ConsultaCEP(string nrCEP)
        {
            var cep = new DadosCEP();
            cep = DadosCEPController.BuscaDados(nrCEP);

            return cep;
        }
    }
}

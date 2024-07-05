using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalaDeEscape.Models;

namespace SalaDeEscape.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Tutorial()
    {
        return View();
    }
    public IActionResult Victoria()
    {
        return View();
    }
    public IActionResult Habitacion(string clave){
        int sala = Escape.GetEstadoJuego();

        if (sala == Escape.GetEstadoJuego())
        {
            if(Escape.ResolverSala(sala, clave)){
                if(Escape.TerminoSala()){
                    return View("Victoria");
                }
            }
            else{
                ViewBag.Error = "La respuesta escrita es incorrecta";
            }

            return View("Mapa");
        }
        else{
            return RedirectToAction();
        }
    }

    public IActionResult Comenzar(){
        return View("Mapa");
    }

    public IActionResult IrASala(int numeroSala){
        return View($"Sala{numeroSala}");    
    }

    public IActionResult ApretoBoton(string ApretoBoton){
        if(ApretoBoton == "1"){
            ViewBag.activoSala = "5";
            Console.WriteLine($"1 + {ViewBag.activoSala}");
        }

        return View($"Sala{Escape.GetEstadoJuego()}");
    }
}

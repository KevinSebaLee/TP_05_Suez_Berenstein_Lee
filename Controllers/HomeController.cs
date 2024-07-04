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
    public IActionResult Habitacion(int sala, string clave){
        if (sala == Escape.GetEstadoJuego())
        {
            if(Escape.ResolverSala(sala, clave)){
                if(Escape.TerminoSala()){
                    return View("Victoria");
                }
                View();
            }
            else{
                ViewBag.Error = "La respuesta escrita es incorrecta";
                RedirectToAction();
            }
        }
        else{
            RedirectToAction();
        }
        return View();
    }

    public IActionResult Comenzar(){
        return View("Mapa");
    }

    public IActionResult IrASala(int numeroSala){
        return View($"Sala{numeroSala}");    
    }

    public IActionResult ApretoBoton(int ApretoBoton){
        if(ApretoBoton == 1){
            ViewBag.activoSala = ApretoBoton;
            Console.WriteLine(ViewBag.activoSala);
        }

        return View($"Sala{Escape.GetEstadoJuego()}");
    }
}

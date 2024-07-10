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

    public IActionResult Creditos(){
        return View();
    }

    public IActionResult Habitacion(string clave){
        int sala = Escape.GetEstadoJuego();

        if(Escape.ResolverSala(clave.ToLower())){
            if(Escape.TerminoSala()){
                return View("Victoria");
            }

            return View("Mapa");
        }
        else{
            ViewBag.Error = "La respuesta escrita es incorrecta";

            return View($"Sala{sala}");
        }
    }

    public IActionResult Comenzar(){
        Escape.InicializarJuego();
        return View("Mapa");
    }

    public IActionResult IrASala(int numeroSala){
        if(numeroSala <= 5){
            Escape.estadoJuego = numeroSala;
            return View($"Sala{numeroSala}");
        }
        else if(numeroSala > 5 && numeroSala < 10)
        {
            if(Escape.Graph.seIngresa(1) == true && Escape.Graph.seIngresa(2) == true && Escape.Graph.seIngresa(3) == true && Escape.Graph.seIngresa(4) == true && Escape.Graph.seIngresa(5) == true){
                Escape.estadoJuego = numeroSala;
                return View($"Sala{numeroSala}");
            }
            else{
                Console.WriteLine("Hola");
                return View("Mapa");
            }
        }
        else if(numeroSala >= 10){
            if(Escape.Graph.seIngresa(14)){
                Escape.estadoJuego = numeroSala;
                return View($"Sala{numeroSala}");
            }
            else{
                return View("Mapa");
            }
        }
        else{
            return View("Mapa");
        }
    }

    public IActionResult ApretoBoton(string ApretoBoton){
        if(ApretoBoton == "1"){
            ViewBag.activoSala = "5";
        }

        return View($"Sala{Escape.GetEstadoJuego()}");
    }
}

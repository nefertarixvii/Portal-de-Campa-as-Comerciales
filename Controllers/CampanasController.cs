using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;

public class CampanasController : Controller
{
    static List<Campania> campanias = new List<Campania>
    {
        new Campania { Id=1, Nombre="Electro Fest", Categoria="Electro", Estado="Vigente", Canal="Web", DescuentoPct=20, FechaInicio=DateTime.Now.AddDays(-5), FechaFin=DateTime.Now.AddDays(5), Descripcion="Ofertas en electro" },
        new Campania { Id=2, Nombre="Moda Verano", Categoria="Moda", Estado="Próxima", Canal="App", DescuentoPct=15, FechaInicio=DateTime.Now.AddDays(10), FechaFin=DateTime.Now.AddDays(20), Descripcion="Ropa verano" }
    };

    public IActionResult Index()
    {
        return View(campanias);
    }
}

using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;

public class CampanasController : Controller
{
    static List<Campania> campanias = new List<Campania>
    {
        new Campania { Id=1, Nombre="Electro Fest", Categoria="Electro", Estado="Vigente", Canal="Web", DescuentoPct=20, FechaInicio=DateTime.Now.AddDays(-5), FechaFin=DateTime.Now.AddDays(5), Descripcion="Ofertas en electro" },
        new Campania { Id=2, Nombre="Moda Verano", Categoria="Moda", Estado="Próxima", Canal="App", DescuentoPct=15, FechaInicio=DateTime.Now.AddDays(10), FechaFin=DateTime.Now.AddDays(20), Descripcion="Ropa verano" }
    };

    public IActionResult Index(string categoria, string estado)
    {
        var resultado = campanias.AsEnumerable();

        if (!string.IsNullOrEmpty(categoria))
            resultado = resultado.Where(c => c.Categoria == categoria);

        if (!string.IsNullOrEmpty(estado))
            resultado = resultado.Where(c => c.Estado == estado);

        ViewData["categoria"] = categoria;
        ViewData["estado"] = estado;

        return View(resultado.ToList());
    }

    public IActionResult Detalle(int id)
    {
    var campana = campanias.FirstOrDefault(c => c.Id == id);
    if (campana == null)
        return NotFound(); // o puedes mostrar un mensaje de "no encontrado"

    return View(campana);
    }

    public IActionResult Resumen()
    {
        var total = campanias.Count;
        var vigentes = campanias.Count(c => c.Estado == "Vigente");
        var proximas = campanias.Count(c => c.Estado == "Próxima");
        var promedio = campanias.Average(c => c.DescuentoPct);

        var porCanal = campanias
            .GroupBy(c => c.Canal)
            .Select(g => new {
                Canal = g.Key,
             Cantidad = g.Count()
            })
            .ToList();

        ViewData["total"] = total;
        ViewData["vigentes"] = vigentes;
        ViewData["proximas"] = proximas;
        ViewData["promedio"] = promedio;
        ViewData["porCanal"] = porCanal;

        return View();
    }

    
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppFormularioDePago.Models;
namespace AppFormularioDePago.Controllers;

public class PagoController : Controller
{
    private readonly ILogger<PagoController> _logger;

    public PagoController(ILogger<PagoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Pagar(string numeroTarjeta, DateTime fechaVencimiento,string monto)
    {
        PagoModel _pago = new PagoModel();
        DateTime hoy = DateTime.Now;
        TimeSpan diferencia = hoy.Subtract(fechaVencimiento);
        int diasDeDiferencia = diferencia.Days;
        double montoDecimal = double.Parse(monto);
        double montoFinal = montoDecimal + montoDecimal*diasDeDiferencia*(100/0.005);
        _pago.NumeroTarjeta = numeroTarjeta;
        _pago.FechaVencimiento = fechaVencimiento;
        _pago.Monto = montoFinal;
        return View(_pago);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}

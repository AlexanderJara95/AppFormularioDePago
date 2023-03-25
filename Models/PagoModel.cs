using System;

namespace AppFormularioDePago.Models;

public class PagoModel
{
    public int Id { get; set; }
    public string NumeroTarjeta { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public decimal Monto { get; set; }
}

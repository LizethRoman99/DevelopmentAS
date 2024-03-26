using System;
using System.Collections.Generic;

namespace DevelopmentAS2.Models;

public partial class EstampadoProducto
{
    public int IdEstampadoProducto { get; set; }

    public int IdCatalogoP { get; set; }

    public int IdEstampado { get; set; }

    public string Ubicacion { get; set; } = null!;

    public decimal Subtotal { get; set; }

    public virtual CatalogoProducto IdCatalogoPNavigation { get; set; } = null!;
}

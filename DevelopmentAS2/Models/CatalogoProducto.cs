using System;
using System.Collections.Generic;

namespace DevelopmentAS2.Models;

public partial class CatalogoProducto
{
    public int IdcatalogoProducto { get; set; }

    public int IdFichaTecnica { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public string TipoEstampado { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int Stock { get; set; }

    public string TamañoEstampado { get; set; } = null!;

    public decimal PrecioProducto { get; set; }

    public string TipoCatalogo { get; set; } = null!;

    public string? ImagenProducto { get; set; }

    public virtual ICollection<EstampadoProducto> EstampadoProductos { get; set; } = new List<EstampadoProducto>();

    public virtual FichasTecnica IdFichaTecnicaNavigation { get; set; } = null!;
}

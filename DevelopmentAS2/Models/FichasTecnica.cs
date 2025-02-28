﻿using System;
using System.Collections.Generic;

namespace DevelopmentAS2.Models;

public partial class FichasTecnica
{
    public int IdFicha { get; set; }

    public string NombreFichaTecnica { get; set; } = null!;

    public bool EstadoFicha { get; set; }

    public string Talla { get; set; } = null!;

    public string? Color { get; set; }

    public virtual ICollection<CatalogoProducto> CatalogoProductos { get; set; } = new List<CatalogoProducto>();

    public virtual ICollection<FichasTecInsumo> FichasTecInsumos { get; set; } = new List<FichasTecInsumo>();

    public virtual ICollection<ProductoTerminado> ProductoTerminados { get; set; } = new List<ProductoTerminado>();
}

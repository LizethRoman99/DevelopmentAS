﻿using System;
using System.Collections.Generic;

namespace DevelopmentAS2.Models;

public partial class Compra
{
    public int Idcompra { get; set; }

    public string NombreInsumo { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public string Recibo { get; set; } = null!;

    public decimal Iva { get; set; }

    public int IdProveedor { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<ComprasInsumo> ComprasInsumos { get; set; } = new List<ComprasInsumo>();

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
}

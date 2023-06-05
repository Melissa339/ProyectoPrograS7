using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Departamento
{
    public Guid IdDepartamento { get; set; }

    public string? Nombre { get; set; }

    public bool? EstadoEliminado { get; set; }

    public virtual ICollection<Mesa> Mesas { get; } = new List<Mesa>();
}

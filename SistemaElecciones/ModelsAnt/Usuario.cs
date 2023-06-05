using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Mesa> Mesas { get; } = new List<Mesa>();
}

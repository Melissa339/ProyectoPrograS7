using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace SistemaElecciones.Models;

public partial class Partido
{
    public Guid IdPartido { get; set; }

    public DateTime FechaFundacion { get; set; }

    public string? Sede { get; set; }

    public string? Nombre { get; set; }

    public bool? EstadoEliminado { get; set; }

    public virtual ICollection<Candidato> Candidatos { get; } = new List<Candidato>();

    public void BeforeSaveChanges()
    {
        Sede ??= string.Empty;
        Nombre ??= string.Empty;
    }
}

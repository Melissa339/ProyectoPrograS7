using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Voto
{
    public Guid IdVoto { get; set; }

    public Guid IdCandidato { get; set; }

    public Guid IdMesa { get; set; }

    public string? DpiCiudadano { get; set; }

    public bool EstadoEliminado { get; set; }

    public virtual Candidato? IdCandidatoNavigation { get; set; }

    public virtual Mesa? IdMesaNavigation { get; set; }

    public void BeforeSaveChanges()
    {
        DpiCiudadano ??= string.Empty;
    }
}

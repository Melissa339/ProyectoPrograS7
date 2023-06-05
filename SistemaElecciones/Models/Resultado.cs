using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Resultado
{
    public Guid IdResultado { get; set; }

    public Guid? IdCandidato { get; set; }

    public int? Votos { get; set; }

    public bool? EstadoEliminado { get; set; }

    public virtual Candidato? IdCandidatoNavigation { get; set; }
}

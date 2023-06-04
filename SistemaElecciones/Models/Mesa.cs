using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaElecciones.Models;

public partial class Mesa
{
    public Guid IdMesa { get; set; }

    public Guid? IdUsuario { get; set; }

    public int? CantidadVotos { get; set; }

    public string? Ubicacion { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Voto> Votos { get; } = new List<Voto>();
   
    public virtual Departamento Departamentos { get; set; }
}

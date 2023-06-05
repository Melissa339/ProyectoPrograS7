using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Mesa
{
    public Guid IdMesa { get; set; }

    public Guid? IdUsuario { get; set; }

    public Guid? IdUbicacion { get; set; }

    public int? CantidadVotos { get; set; }

    public virtual Departamento? IdUbicacionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Voto> Votos { get; } = new List<Voto>();
}

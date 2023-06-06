using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace SistemaElecciones.Models;

public partial class Mesa
{
    public Guid IdMesa { get; set; }

    public Guid? IdUsuario { get; set; }

    public Guid? IdUbicacion { get; set; }

    public int? CantidadVotos { get; set; }

    public bool? EstadoEliminado { get; set; }

    public string? NumMesa { get; set; }

    public string? NumFolio { get; set; }

    public virtual Departamento? IdUbicacionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Voto> Votos { get; } = new List<Voto>();

    public void BeforeSaveChanges()
    {
        CantidadVotos ??= 0;
        NumMesa ??= string.Empty;
        NumFolio ??= string.Empty;
    }
}

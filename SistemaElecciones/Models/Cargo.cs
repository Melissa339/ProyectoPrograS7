﻿using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Cargo
{
    public Guid IdCargo { get; set; }

    public string? Descripcion { get; set; }

    public bool? EstadoEliminado { get; set; }

    public virtual ICollection<Candidato> Candidatos { get; } = new List<Candidato>();

    public void BeforeSaveChanges()
    {
        Descripcion ??= string.Empty;
    }
}

﻿using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Partido
{
    public Guid IdPartido { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Candidato> Candidatos { get; } = new List<Candidato>();
}

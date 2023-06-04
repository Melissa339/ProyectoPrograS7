﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Candidato
{
    public Guid IdCandidato { get; set; }

    public Guid? IdPartido { get; set; }

    public Guid? IdCargo { get; set; }

    public string? Dpi { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public int? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Profesion { get; set; }

    public string? Antecedentes { get; set; }

    public virtual Cargo? IdCargoNavigation { get; set; }

    public virtual Partido? IdPartidoNavigation { get; set; }

    public virtual ICollection<Resultado> Resultados { get; } = new List<Resultado>();

    public virtual ICollection<Voto> Votos { get; } = new List<Voto>();
}

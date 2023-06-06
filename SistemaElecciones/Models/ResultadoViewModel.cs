using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class ResultadoViewModel
{
    public List<Resultado> resultados { get; set; }
    public List<Candidato> candidatos { get; set; }
    public List<Cargo> cargos { get; set; }
}

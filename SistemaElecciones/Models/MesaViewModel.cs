using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class MesasViewModel
{
    public List<Mesa> mesas { get; set; }
    public List<Usuario> usuarios { get; set; }
    public List<Departamento> departamentos { get; set;}
}

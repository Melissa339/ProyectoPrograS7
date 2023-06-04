using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SistemaElecciones.Models;

public partial class Departamento
{
    public Guid IdDepartamento{ get; set; }

    public string nombre { get; set; }

}

namespace SistemaElecciones.Models
{
    public class VotoViewModel
    {
        public List<Voto>? Votos { get; set; }
        public List<Candidato>? Candidatos { get; set; }
        public List<Mesa>? Mesas { get; set; }
        public List<Cargo> Cargos { get; set; }

        public List<Departamento>? Departamentos { get; set;}

        public Voto? Voto { get; set; }
    }
}

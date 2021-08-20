using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTrabajo.Models
{
    public class proyectos
    {
        [Key]

        public int IdProyecto { get; set; }

        public string Nombre { get; set; }
        public int IdEmpresa { get; set; }

        public Empresa Empresa { get; set; }

        public virtual ICollection<HistoriaUsuario> HistoriaUsuario { get; set; }
    }
}
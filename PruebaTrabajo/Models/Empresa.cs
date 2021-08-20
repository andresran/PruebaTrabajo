using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTrabajo.Models
{
    public class Empresa
    {
        [Key]

        public int IdEmpresa { get; set; }

        public string Nombre { get; set; }

        public int Nit { get; set; }

        public int Telefono { get; set; }

        public string Correo { get; set; }

        public virtual ICollection<proyectos> proyectos { get; set; }
    }
}
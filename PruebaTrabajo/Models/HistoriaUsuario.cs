using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTrabajo.Models
{
    public class HistoriaUsuario
    {
        [Key]
        public int IdHistoriaUsuario { get; set; }

        public string Nombre { get; set; }

        public int IdProyecto { get; set; }

        public proyectos proyectos { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
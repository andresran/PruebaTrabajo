using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTrabajo.Models
{
    public class Ticket
    {
        [Key]
        public int IdTickets { get; set; }
        public string Comentarios { get; set; }
        public string Estado { get; set; }
        public virtual HistoriaUsuario HistoriaUsuario { get; set; }
    }
}
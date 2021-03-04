using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Repuesto
    {
        public Repuesto()
        {
            SolicitudSerRepuesto = new HashSet<SolicitudSerRepuesto>();
        }

        public int CodRep { get; set; }
        public byte CodTipo { get; set; }
        public byte CodCalRep { get; set; }
        public string NomRep { get; set; }
        public decimal VlrRep { get; set; }

        public virtual CalidadRepuesto CodCalRepNavigation { get; set; }
        public virtual TipoRepuesto CodTipoNavigation { get; set; }
        public virtual ICollection<SolicitudSerRepuesto> SolicitudSerRepuesto { get; set; }
    }
}

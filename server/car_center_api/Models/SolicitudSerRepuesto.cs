using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class SolicitudSerRepuesto
    {
        public SolicitudSerRepuesto()
        {
            FacturaDeta = new HashSet<FacturaDeta>();
        }

        public int CodSolSerRep { get; set; }
        public int CodSolic { get; set; }
        public int CodRep { get; set; }
        public byte Cantidad { get; set; }

        public virtual Repuesto CodRepNavigation { get; set; }
        public virtual SolicitudServ CodSolicNavigation { get; set; }
        public virtual ICollection<FacturaDeta> FacturaDeta { get; set; }
    }
}

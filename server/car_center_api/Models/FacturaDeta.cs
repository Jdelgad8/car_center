using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class FacturaDeta
    {
        public int CodFacDet { get; set; }
        public int CodFacEnc { get; set; }
        public int CodSolic { get; set; }
        public int CodSolSerRep { get; set; }
        public int VlrSub { get; set; }

        public virtual FacturaEnca CodFacEncNavigation { get; set; }
        public virtual SolicitudSerRepuesto CodSolSerRepNavigation { get; set; }
        public virtual SolicitudServ CodSolicNavigation { get; set; }
    }
}

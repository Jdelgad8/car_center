using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class FacturaEnca
    {
        public FacturaEnca()
        {
            FacturaDeta = new HashSet<FacturaDeta>();
        }

        public int CodFacEnc { get; set; }
        public string CodEstFac { get; set; }
        public int CodCli { get; set; }
        public int CodMec { get; set; }
        public byte CodPago { get; set; }
        public decimal? VlrDcto { get; set; }
        public DateTime FecFac { get; set; }
        public decimal VlrTot { get; set; }
        public decimal VlrIva { get; set; }

        public virtual Cliente CodCliNavigation { get; set; }
        public virtual EstFactura CodEstFacNavigation { get; set; }
        public virtual Mecanico CodMecNavigation { get; set; }
        public virtual MedioPago CodPagoNavigation { get; set; }
        public virtual ICollection<FacturaDeta> FacturaDeta { get; set; }
    }
}

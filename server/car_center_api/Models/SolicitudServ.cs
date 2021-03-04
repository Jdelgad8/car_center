using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class SolicitudServ
    {
        public SolicitudServ()
        {
            FacturaDeta = new HashSet<FacturaDeta>();
            SolicitudSerRepuesto = new HashSet<SolicitudSerRepuesto>();
        }

        public int CodSolic { get; set; }
        public byte CodSer { get; set; }
        public int CodVeh { get; set; }
        public int CodMec { get; set; }
        public string CodEstServ { get; set; }
        public decimal VlrSer { get; set; }
        public DateTime FecSol { get; set; }
        public DateTime FecEst { get; set; }
        public DateTime? FecTer { get; set; }

        public virtual EstadoServicio CodEstServNavigation { get; set; }
        public virtual Mecanico CodMecNavigation { get; set; }
        public virtual Serviciot CodSerNavigation { get; set; }
        public virtual Vehiculo CodVehNavigation { get; set; }
        public virtual ICollection<FacturaDeta> FacturaDeta { get; set; }
        public virtual ICollection<SolicitudSerRepuesto> SolicitudSerRepuesto { get; set; }
    }
}

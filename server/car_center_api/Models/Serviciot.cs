using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Serviciot
    {
        public Serviciot()
        {
            SolicitudServ = new HashSet<SolicitudServ>();
        }

        public byte CodSer { get; set; }
        public byte CodTipo { get; set; }
        public decimal VlrMin { get; set; }
        public decimal VlrMax { get; set; }
        public int DurMin { get; set; }

        public virtual TipoServicio CodTipoNavigation { get; set; }
        public virtual ICollection<SolicitudServ> SolicitudServ { get; set; }
    }
}

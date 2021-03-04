using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class EstadoServicio
    {
        public EstadoServicio()
        {
            SolicitudServ = new HashSet<SolicitudServ>();
        }

        public string CodEstServ { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<SolicitudServ> SolicitudServ { get; set; }
    }
}

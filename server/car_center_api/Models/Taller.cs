using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Taller
    {
        public Taller()
        {
            Mecanico = new HashSet<Mecanico>();
        }

        public int CodTaller { get; set; }
        public byte CodZona { get; set; }
        public string NroCel { get; set; }
        public string Direccion { get; set; }
        public DateTime FecReg { get; set; }

        public virtual Zonat CodZonaNavigation { get; set; }
        public virtual ICollection<Mecanico> Mecanico { get; set; }
    }
}

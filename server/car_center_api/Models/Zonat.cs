using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Zonat
    {
        public Zonat()
        {
            Cliente = new HashSet<Cliente>();
            Mecanico = new HashSet<Mecanico>();
            Taller = new HashSet<Taller>();
        }

        public byte CodZona { get; set; }
        public byte CodCiu { get; set; }
        public string NomZona { get; set; }

        public virtual Ciudad CodCiuNavigation { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Mecanico> Mecanico { get; set; }
        public virtual ICollection<Taller> Taller { get; set; }
    }
}

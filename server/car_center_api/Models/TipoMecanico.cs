using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class TipoMecanico
    {
        public TipoMecanico()
        {
            Mecanico = new HashSet<Mecanico>();
        }

        public byte CodTipo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Mecanico> Mecanico { get; set; }
    }
}

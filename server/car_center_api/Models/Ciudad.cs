using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Zonat = new HashSet<Zonat>();
        }

        public byte CodCiu { get; set; }
        public byte CodDep { get; set; }
        public string Descripcion { get; set; }

        public virtual Departamento CodDepNavigation { get; set; }
        public virtual ICollection<Zonat> Zonat { get; set; }
    }
}

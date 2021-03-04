using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Ciudad = new HashSet<Ciudad>();
        }

        public byte CodDep { get; set; }
        public byte CodPais { get; set; }
        public string Descripcion { get; set; }

        public virtual Pais CodPaisNavigation { get; set; }
        public virtual ICollection<Ciudad> Ciudad { get; set; }
    }
}

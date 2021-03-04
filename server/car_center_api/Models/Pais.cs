using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Departamento = new HashSet<Departamento>();
        }

        public byte CodPais { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Departamento> Departamento { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class MedioPago
    {
        public MedioPago()
        {
            FacturaEnca = new HashSet<FacturaEnca>();
        }

        public byte CodPago { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<FacturaEnca> FacturaEnca { get; set; }
    }
}

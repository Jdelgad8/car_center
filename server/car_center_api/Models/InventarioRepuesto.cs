using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class InventarioRepuesto
    {
        public int CodRep { get; set; }
        public int CodTaller { get; set; }
        public int Cantidad { get; set; }
        public DateTime FecAct { get; set; }
    }
}

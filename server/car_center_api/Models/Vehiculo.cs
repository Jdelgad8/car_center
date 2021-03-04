using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            EstVehiculo = new HashSet<EstVehiculo>();
            SolicitudServ = new HashSet<SolicitudServ>();
        }

        public int CodVeh { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public DateTime Modelo { get; set; }
        public string Color { get; set; }

        public virtual ICollection<EstVehiculo> EstVehiculo { get; set; }
        public virtual ICollection<SolicitudServ> SolicitudServ { get; set; }
    }
}

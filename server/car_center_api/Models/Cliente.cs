using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            FacturaEnca = new HashSet<FacturaEnca>();
        }

        public int CodCli { get; set; }
        public byte CodZona { get; set; }
        public string TipoDoc { get; set; }
        public string PrimNom { get; set; }
        public string SeguNom { get; set; }
        public string PrimApe { get; set; }
        public string SeguApe { get; set; }
        public string NroDoc { get; set; }
        public string NroCel { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public decimal? VlrMax { get; set; }
        public DateTime FecReg { get; set; }

        public virtual Zonat CodZonaNavigation { get; set; }
        public virtual TipoDoc TipoDocNavigation { get; set; }
        public virtual ICollection<FacturaEnca> FacturaEnca { get; set; }
    }
}

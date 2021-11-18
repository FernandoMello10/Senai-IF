using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Models
{
    public partial class RegistroMaterial
    {
        public int? IdMaterial { get; set; }
        public int? IdChamado { get; set; }
        public int? Quantidade { get; set; }

        public virtual Chamado IdChamadoNavigation { get; set; }
        public virtual Material IdMaterialNavigation { get; set; }
    }
}

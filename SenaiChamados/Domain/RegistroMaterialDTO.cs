using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Domain
{
    public partial class RegistroMaterialDTO
    {
        public int? IdMaterial { get; set; }
        public int? IdChamado { get; set; }
        public int? Quantidade { get; set; }

        public virtual ChamadoDTO IdChamadoNavigation { get; set; }
        public virtual MaterialDTO IdMaterialNavigation { get; set; }
    }
}

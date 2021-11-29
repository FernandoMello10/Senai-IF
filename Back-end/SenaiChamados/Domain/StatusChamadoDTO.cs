using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Domain
{
    public partial class StatusChamadoDTO
    {
        public StatusChamadoDTO()
        {
            Chamados = new HashSet<ChamadoDTO>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ChamadoDTO> Chamados { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Domain
{
    public partial class ChamadoDTO
    {
        public int Id { get; set; }
        public int? IdPrioridade { get; set; }
        public int? IdStatus { get; set; }
        public int? IdAutor { get; set; }
        public int? IdResponsavel { get; set; }
        public string Descricao { get; set; }
        public string Lugar { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataDeFinalicao { get; set; }

        public virtual UsuarioDTO IdAutorNavigation { get; set; }
        public virtual PrioridadeDTO IdPrioridadeNavigation { get; set; }
        public virtual UsuarioDTO IdResponsavelNavigation { get; set; }
        public virtual StatusChamadoDTO IdStatusNavigation { get; set; }
    }
}

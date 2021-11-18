using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Models
{
    public partial class Chamado
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

        public virtual Usuario IdAutorNavigation { get; set; }
        public virtual Prioridade IdPrioridadeNavigation { get; set; }
        public virtual Usuario IdResponsavelNavigation { get; set; }
        public virtual StatusChamado IdStatusNavigation { get; set; }
    }
}

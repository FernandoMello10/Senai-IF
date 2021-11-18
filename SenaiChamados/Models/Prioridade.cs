using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Models
{
    public partial class Prioridade
    {
        public Prioridade()
        {
            Chamados = new HashSet<Chamado>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Chamado> Chamados { get; set; }
    }
}

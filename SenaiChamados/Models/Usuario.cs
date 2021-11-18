using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ChamadoIdAutorNavigations = new HashSet<Chamado>();
            ChamadoIdResponsavelNavigations = new HashSet<Chamado>();
        }

        public int Id { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdSetor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        public virtual Setor IdSetorNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Chamado> ChamadoIdAutorNavigations { get; set; }
        public virtual ICollection<Chamado> ChamadoIdResponsavelNavigations { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Domain
{
    public partial class UsuarioDTO
    {
        public UsuarioDTO()
        {
            ChamadoIdAutorNavigations = new HashSet<ChamadoDTO>();
            ChamadoIdResponsavelNavigations = new HashSet<ChamadoDTO>();
        }

        public int Id { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdSetor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        public virtual SetorDTO IdSetorNavigation { get; set; }
        public virtual TipoUsuarioDTO IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<ChamadoDTO> ChamadoIdAutorNavigations { get; set; }
        public virtual ICollection<ChamadoDTO> ChamadoIdResponsavelNavigations { get; set; }
    }
}

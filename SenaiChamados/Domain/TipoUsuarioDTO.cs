﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Domain
{
    public partial class TipoUsuarioDTO
    {
        public TipoUsuarioDTO()
        {
            Usuarios = new HashSet<UsuarioDTO>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<UsuarioDTO> Usuarios { get; set; }
    }
}

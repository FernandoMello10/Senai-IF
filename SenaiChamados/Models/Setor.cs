﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Models
{
    public partial class Setor
    {
        public Setor()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
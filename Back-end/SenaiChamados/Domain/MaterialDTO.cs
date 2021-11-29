using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiChamados.Domain
{
    public partial class MaterialDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Quantidade { get; set; }
    }
}

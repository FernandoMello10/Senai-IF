using System;

namespace SenaiChamados.Models
{
    public class ChamadoModel
    {
        public DateTime DataCriacao { get; set; }   
        public DateTime DataFinalizacao { get; set; }
        public UsuarioModel Responsavel { get; set; }
        public UsuarioModel Autor { get; set; }
        public PrioridadeModel Prioridade { get; set; }
        public SetorModel Setor { get; set; }
        public StatusModel Status { get; set; }
        public string Descricao { get; set; }
        public string Lugar { get; set; }
    }
}

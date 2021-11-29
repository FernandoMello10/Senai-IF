using System;

namespace SenaiChamados.Models
{
    public class ContractModel
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

        public ContractModel()
        {
            
        }
    }
}

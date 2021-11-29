namespace SenaiChamados.Models
{
    public class PrioridadeModel
    {
        public int ID { get; set; }
        public string Descricao { get; set; }

        /// <summary>
        /// Representa a ordem de prioridade. 
        /// 2 é o mais importante, 0 é o menos importante
        /// </summary>
        public int IndicePrioridade { get; set; }
    }
}

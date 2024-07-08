namespace UneContChallenge.Domain.Entities
{
    public class FiltroDashboardIndicadores
    {
        public decimal ValorEmitido { get; set; }
        public decimal ValorSemCobranca { get; set; }
        public decimal ValorVencido { get; set; }
        public decimal ValorVencer { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}

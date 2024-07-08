namespace UneContChallenge.Application.ViewModels
{
    public class FiltroDashboardIndicadoresViewModel
    {
        public int Id { get; set; }
        public decimal ValorEmitido { get; set; }
        public decimal ValorSemCobranca { get; set; }
        public decimal ValorVencido { get; set; }
        public decimal ValorVencer { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}

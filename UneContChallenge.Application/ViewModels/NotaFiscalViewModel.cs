﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UneContChallenge.Application.ViewModels
{
    public class NotaFiscalViewModel
    {
        public int Id { get; set; }

        public string NomePagador { get; set; }

        public string NumeroIdentificacao { get; set; }

        public DateTime DataEmissao { get; set; }

        public DateTime? DataCobranca { get; set; }

        public DateTime? DataPagamento { get; set; }

        public decimal Valor { get; set; }

        public string DocumentoNotaFiscal { get; set; }
        public string DocumentoBoletoBancario { get; set; }

        public string Status { get; set; }
    }
}

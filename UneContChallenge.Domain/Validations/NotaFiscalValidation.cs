using FluentValidation;
using UneContChallenge.Domain.Entities;

namespace UneContChallenge.Domain.Validations
{
    public class NotaFiscalValidation : AbstractValidator<NotaFiscal>
    {
        public NotaFiscalValidation()
        {
            RuleFor(n => n.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(n => n.NomePagador)
                .NotEmpty()
                .WithMessage("O nome do pagador é obrigatório.");

            RuleFor(n => n.NumeroIdentificacao)
                .NotEmpty()
                .WithMessage("O número de identificação da nota é obrigatório.");

            RuleFor(n => n.Status)
                .NotEmpty()
                .WithMessage("O status da nota é obrigatório.");

            RuleFor(n => n.Valor)
                .NotEmpty()
                .WithMessage("O valor da nota é obrigatório.");

            RuleFor(n => n.DocumentoBoletoBancario)
                .NotEmpty()
                .WithMessage("O documento do boleto bancário é obrigatório.");

            RuleFor(n => n.DocumentoNotaFiscal)
                .NotEmpty()
                .WithMessage("O documento da nota fiscal é obrigatório.");

            RuleFor(n => n.DataEmissao)
                .NotEmpty()
                .WithMessage("A data de emissão da nota é obrigatória.");
        }
    }
}

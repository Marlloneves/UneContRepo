using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UneContChallenge.Domain.Entities;

namespace UneContChallenge.Infra.Mappings
{
    public class NotaFiscalMappings : BaseMappings<NotaFiscal>
    {
        public override void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            base.Configure(builder);
            builder.HasKey(n => n.Id);
            builder.ToTable("NotaFiscal");
            builder.Property(n => n.NomePagador)
                .IsRequired()
                .HasColumnName("NomePagador")
                .HasMaxLength(50);

            builder.Property(n => n.NumeroIdentificacao)
                .IsRequired()
                .HasColumnName("NumeroIdentificacao")
                .HasMaxLength(80);

            builder.Property(n => n.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasMaxLength(25);

            builder.Property(n => n.Valor)
                .IsRequired()
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Valor");

            builder.Property(n => n.DocumentoBoletoBancario)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("DocumentoBoletoBancario");

            builder.Property(n => n.DocumentoNotaFiscal)
                .IsRequired()
                .HasColumnName("DocumentoNotaFiscal")
                .HasMaxLength(250);

            builder.Property(n => n.DataPagamento)
                .HasColumnName("DataPagamento");

            builder.Property(n => n.DataEmissao)
                .IsRequired()
                .HasColumnName("DataEmissao");

            builder.Property(n => n.DataCobranca)
                .IsRequired(false)
                .HasColumnName("DataCobranca");
        }
    }
}

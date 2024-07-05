using Microsoft.EntityFrameworkCore;
using UneContChallenge.Domain.Entities;
using UneContChallenge.Infra.Mappings;

namespace UneContChallenge.Infra.Contexts
{
    public class DataContexts : DbContext
    {
        public DataContexts(DbContextOptions<DataContexts> dbContextOptions)
            :base (dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotaFiscalMappings());
        }

        public DbSet<NotaFiscal> NotaFiscal { get; set; }
    }
}

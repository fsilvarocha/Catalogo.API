using Catalogo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.API.Context
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
            modelBuilder.Entity<Categoria>().Property(c => c.Nome).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Descricao).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Imagem).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Produto>().Property(p=>p.QtdeEstoque).HasDefaultValue(0);
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasPrecision(18, 2).IsRequired();

            modelBuilder.Entity<Produto>()
                .HasOne<Categoria>(c => c.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(c => c.CategoriaId);

            

            base.OnModelCreating(modelBuilder);
        }
    }
}

﻿using Games.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");
            _ = modelBuilder.Entity<Produto>()
               .HasOne(_ => _.Categoria)
               .WithMany(t => t.Produto)
               .HasForeignKey("CategoriaId")
               .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Produto> Produtos {get; set;} = null!;
        public DbSet<Categoria> Categorias {get; set;} = null!;


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
                                   .Where(x => x.State == EntityState.Added)
                                   .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                //Se uma propriedade da Classe Auditable estiver sendo criada. 
                if (insertedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = new DateTimeOffset(DateTime.Now, new TimeSpan(-3, 0, 0));
                }
            }

            var modifiedEntries = ChangeTracker.Entries()
                       .Where(x => x.State == EntityState.Modified)
                       .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                //Se uma propriedade da Classe Auditable estiver sendo atualizada.  
                if (modifiedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = new DateTimeOffset(DateTime.Now, new TimeSpan(-3, 0, 0));
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private DateTimeOffset? DateTimeOffset(DateTime now, TimeSpan timeSpan)
            {
                throw new NotImplementedException();
            }


        }     
    }



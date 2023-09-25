using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectArchitecture.Domain.Entities;

namespace ProjectArchitecture.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();


            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

            // Esse trecho de código abaixo é opcional. Ele está apenas adicionando uma carga inicial de dados na tabela ao ser criada.
            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios")
                );
        }
    }
}

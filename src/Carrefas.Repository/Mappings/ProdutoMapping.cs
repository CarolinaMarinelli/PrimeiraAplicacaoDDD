using Carrefas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrefas.Repository.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto> //é uma interface do próprio Entity framework e passa o produto como referencia
        // Esse frame é configurado para o entity ter mais detalhes sobre o produto 
        //

    {
        //Fluent API
        public void Configure(EntityTypeBuilder<Produto> builder) 
        {
            builder.HasKey(p => p.Id); //esse ID(representação da tabela banco de dados) esta no domian . Isso é para falar para o entity que o ID é a minha chava primaria


            builder.Property(p => p.Id) //pegando a propriedade do ID
               .IsRequired()
               .HasColumnName("Id"); // muda o nome da coluna

            builder.Property(p => p.Nome)
               .IsRequired()
               .HasColumnType("varchar(30)") 
               .HasColumnName("Nome");         

            builder.Property(p => p.Ativo)               
               .HasColumnName("Ativo"); 

            builder.Property(p => p.Descricao) //para passar as propriedades, que aqui seria a descricao
                .IsRequired()//quando receber uma informação do banco de dados, vai dizer que é obrigatório guardar no banco de dados 
                .HasColumnType("varchar(300)")//.HasColumnType("string dentro do banco de dados varchar(1000 - dizendo que o tamamho máximo da descrição é mil)") para dizer o tamanho do campo 
                .HasColumnName("Descricao");


            builder.Property(p => p.Valor)
                .IsRequired()
               .HasPrecision(15, 2);

            builder.ToTable("Produto"); // nome da coluna que vai ser refletido no banco de dados

            // precisa informar no contexto
            // todas essas informações refletem no banco de dados
        }
    }
}

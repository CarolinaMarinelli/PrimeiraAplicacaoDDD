using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrefas.Domain.Models
{
    public class Produto : Entity
    {
        public string? Nome { get; private set; } //quando eu coloco um private aqui, eu não posso setar algo diretamente
        public string? Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }

        public Produto(string? nome, string? descricao, decimal valor, bool ativo)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Ativo = ativo;
        }

        public void AtivarProduto()
        {
            Ativo = true;
        }

        public void InativarProduto()
        {
            Ativo = false;
        }

        public void SetId(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}

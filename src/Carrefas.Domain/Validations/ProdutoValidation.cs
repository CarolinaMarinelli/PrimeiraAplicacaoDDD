using Carrefas.Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Carrefas.Domain.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto> // valida o que ta chegando para o produto conseguir persistir no banco de dados
    {
        public ProdutoValidation()
        {
            RuleFor(c => c.Nome) // validar se o nome no front é diferente de null
                .NotEmpty() // se o campo estiver vazio, vai disparar uma mensagem para o front
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 30) //tamanho mínimo e máxio do nome, caso for menor ou maior, dispara uma mensagem
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Descricao)
                .NotEmpty() 
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 150) 
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Valor) // como é decimal, vai verificar se é maior que zero
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");


        }
    }
}

// FluentValidation vai auxiliar a fazer as validações
// Essas validações precisam ser implementadas dentro do Service
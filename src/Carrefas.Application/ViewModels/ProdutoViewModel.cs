using System.ComponentModel.DataAnnotations;

namespace Carrefas.Application.ViewModels
{
    public class ProdutoViewModel // sua responsabilidade é receber os dados do front 
        //faz isso para bater aqui antes de cair na Fluente Validation, se já estiver inconsistente da erro e não deixa fazer requisição no banco de dados desnecessário
    {
        [Key] //datanotation, falando que o id é a chave primária
        public Guid id { get; set; }

        //[ScaffoldColumn(false)] // ´Para não criar data de cadastro, quer que pegue do servidor
        //public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 30)]
        public string? Descricao { get; set; }     
 

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "O campo {0} precisa ter um valor decimal válido ")]
        public decimal Valor { get; set; }


        public bool Ativo { get; set; }

    }
}

/*o front preenche o formulário, que vai para a controller via json que é transformado em objeto. A controller chama uma classe
 * do tipo viewmodel, então a idéia é transformar a viewmodel em um modelo de entidade. A viewmodel faz uma dto(data transfer object) para o modelo de entidade
 * o dto pega os dados da viewmodel e transforma em modelo de entidade para a integridade da entidade(representação do banco de dados)
 * Dentro da VM pode usar Data Anotation
*/
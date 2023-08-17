using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrefas.Domain.Models
{
    public abstract class Entity //Classe abstract não pode ser instanciada 
    {
        protected Entity() //quando cria um construtor de uma classe abstract, por padrão, se cria um contrutor protected, para só poder receber esses valores quem herdar a classe abstract
        {
            Id = Guid.NewGuid(); //para gerar um Id automaticamente 
            DataCadastro = DateTime.Now;

        }           
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}

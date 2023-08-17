using Carrefas.Domain.Interfaces.Notifications;
using Carrefas.Domain.Models;
using Carrefas.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Carrefas.Domain.Services
{
    public abstract class BaseService //vai abstratir os erros com base na implementação que está fazendo
    {
        private readonly INotifier _notifier; // os contratos

       protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult) //aqui chama o fluentValidation, ele vai percorrer todas as validações e voltar o resultado aqui
        {
            foreach (var error in validationResult.Errors) // vai listar todos os erros que deu na validação
            {
                Notify(error.ErrorMessage); //adicionar a mensagem utilizando o notification 
            }
        } // precisa percorrer as validações para poder listar

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message)); // adiciona item na lista
        }

        protected bool RunValidation<Validation, Entitie>(Validation validation, Entitie entitie) where Validation : AbstractValidator<Entitie> where Entitie : Entity
        {
            var validator = validation.Validate(entitie);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }  // metodo onde vai orquestrar essas validações 
   
    }
}

// essa classe vai ajudar a obter as mensagem com base na classe de produto validation
//Só pode ser utilizado por herança
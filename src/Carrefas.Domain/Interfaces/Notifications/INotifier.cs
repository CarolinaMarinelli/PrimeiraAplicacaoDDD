using Carrefas.Domain.Notifications;

namespace Carrefas.Domain.Interfaces.Notifications
{
    public interface INotifier 
    {
        bool HasNotification(); //existe notificacao
        List<Notification> GetNotifications(); //buscar e listar todas notificacoes
        void Handle(Notification notification);// percorrer as notificações e mandar pra lista
    }
}

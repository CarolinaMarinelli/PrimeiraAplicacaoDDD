using Carrefas.Domain.Interfaces.Notifications;

namespace Carrefas.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications; // foi criado uma lista e iniciada pelo construtor

        public Notifier()// cria o construtor para fazer com que _notifications seja uma lista de notificação
        {
            _notifications = new List<Notification>();
        }
        public void Handle(Notification notification)
        {
            _notifications.Add(notification); //ta passando a notificação para ser adicionado na lista
        }
        public bool HasNotification()
        {
            return _notifications.Any(); // esse Any vai notificar um true ou false se tem algo na lista 
        }
        public List<Notification> GetNotifications()
        {
            return _notifications; // listando as notificações 
        }

    }
}
// o papel é listar as notificacoes que o produto validation vai criar
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrefas.Domain.Notifications
{
    public class Notification
    {
        public Notification(string mensagem) {
            Mensagem = mensagem;
        }
        public string Mensagem { get; }

    }
}
// toda vez que essa classe for instanciada, vai ser obrigado a passar uma mensagem pra ela

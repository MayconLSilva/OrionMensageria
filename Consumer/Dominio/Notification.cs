using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Dominio
{
    public class Notification
    {
        public string tipo { get; set; }
        public string assunto { get; set; }
        public string cliente { get; set; }
        public string mensagem { get; set; }
    }
}

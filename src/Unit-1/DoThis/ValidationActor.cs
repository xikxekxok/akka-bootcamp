using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using WinTail.Messages;

namespace WinTail
{
    public class ValidationActor : UntypedActor
    {
        private readonly IActorRef _consoleWriterActor;

        public ValidationActor(IActorRef consoleWriterActor)
        {
            _consoleWriterActor = consoleWriterActor;
        }

        protected override void OnReceive(object message)
        {
            var s = message as string;

            NotifyWriter(s);

            Sender.Tell(new Message.Continue());
        }

        private void NotifyWriter(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                _consoleWriterActor.Tell(new Message.NullInputError("empty input!"));
                return;
            }

            if (s.Length % 2 == 0)
            {
                _consoleWriterActor.Tell(new Message.InputSuccess("message is ok!"));
                return;
            }

            _consoleWriterActor.Tell(new Message.ValidationInputError("message is invalid!"));
        }
    }
}

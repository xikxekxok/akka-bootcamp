using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using WinTail.MessagesNs;

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

            Sender.Tell(new Messages.Continue());
        }

        private void NotifyWriter(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                _consoleWriterActor.Tell(new Messages.NullInputError("empty input!"));
                return;
            }

            if (s.Length % 2 == 0)
            {
                _consoleWriterActor.Tell(new Messages.InputSuccess("message is ok!"));
                return;
            }

            _consoleWriterActor.Tell(new Messages.ValidationInputError("message is invalid!"));
        }
    }
}

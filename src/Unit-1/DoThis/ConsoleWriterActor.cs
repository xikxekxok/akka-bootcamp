using System;
using Akka.Actor;
using WinTail.MessagesNs;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for serializing message writes to the console.
    /// (write one message at a time, champ :)
    /// </summary>
    class ConsoleWriterActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            var success = message as Messages.InputSuccess;
            if (success != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(success.Reason);
                Console.ResetColor();
                return;
            }

            var error = message as Messages.InputError;
            if (error != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Reason);
                Console.ResetColor();
                return;
            }
            Console.WriteLine(message);
            

        }
    }
}

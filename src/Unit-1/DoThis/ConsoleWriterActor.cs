using System;
using Akka.Actor;
using WinTail.Messages;

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
            if (message is InputSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine((message as InputSuccess).Reason);
                Console.ResetColor();
                return;
            }

            if (message is InputError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine((message as InputError).Reason);
                Console.ResetColor();
                return;
            }
            Console.WriteLine(message);
            

        }
    }
}

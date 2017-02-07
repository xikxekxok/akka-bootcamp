using System;
using Akka.Actor;
using WinTail.MessagesNs;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for reading FROM the console. 
    /// Also responsible for calling <see cref="ActorSystem.Terminate"/>.
    /// </summary>
    class ConsoleReaderActor : UntypedActor
    {
        public const string ExitCommand = "exit";
        public const string StartCommand = "start";

        protected override void OnReceive(object message)
        {
            if (message?.Equals(StartCommand) == true)
                DoPrintInstructions();

            var read = Console.ReadLine();

            if (String.Equals(read, ExitCommand, StringComparison.OrdinalIgnoreCase))
            {
                Context.System.Terminate();
                return;
            }

            Context.ActorSelection("akka://MySystem/user/fileValidator").Tell(read);
        }


        private void DoPrintInstructions()
        {
            Console.WriteLine("Please provide the URI of a log file on disk.");
        }

        
    }
}
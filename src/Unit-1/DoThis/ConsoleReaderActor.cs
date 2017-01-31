using System;
using Akka.Actor;
using WinTail.Messages;

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
        private IActorRef _consoleWriterActor;

        public ConsoleReaderActor(IActorRef consoleWriterActor)
        {
            _consoleWriterActor = consoleWriterActor;
        }

        protected override void OnReceive(object message)
        {
            if (message?.Equals(StartCommand) == true)
                DoPrintInstructions();
            else
            {
                var error = message as Message.InputError;
                if (error != null)
                {
                    _consoleWriterActor.Tell(error);
                }
            }

            var read = Console.ReadLine();

            if (string.IsNullOrEmpty(read))
            {
                Self.Tell(new Message.NullInputError("Input is null!"));
                return;
            }

            if (String.Equals(read, ExitCommand, StringComparison.OrdinalIgnoreCase))
            {
                Context.System.Terminate();
                return;
            }
            
            if (IsValid(read))
            {
                _consoleWriterActor.Tell(new Message.InputSuccess("Everything is good!"));
                Self.Tell(new Message.Continue());
                return;
            }
            
            Self.Tell(new Message.ValidationInputError("Invalid input!"));
        }


        private void DoPrintInstructions()
        {
            Console.WriteLine("Write whatever you want into the console!");
            Console.WriteLine("Some entries will pass validation, and some won't...\n\n");
            Console.WriteLine("Type 'exit' to quit this application at any time.\n");
        }

        private static bool IsValid(string message)
        {
            var valid = message.Length % 2 == 0;
            return valid;
        }
    }
}
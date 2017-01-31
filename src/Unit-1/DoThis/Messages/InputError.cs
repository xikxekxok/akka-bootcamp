namespace WinTail.Messages
{
    public partial class Message
    {
        public class InputError
        {
            public InputError(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; private set; }
        }
    }
}
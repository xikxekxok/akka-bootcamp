namespace WinTail.MessagesNs
{
    public partial class Messages
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
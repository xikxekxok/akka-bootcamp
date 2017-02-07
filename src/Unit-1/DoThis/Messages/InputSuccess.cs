namespace WinTail.MessagesNs
{
    public partial class Messages
    {
        public class InputSuccess
        {
            public InputSuccess(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; private set; }
        }
    }
}
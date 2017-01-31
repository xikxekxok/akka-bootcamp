namespace WinTail.Messages
{
    public partial class Message
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
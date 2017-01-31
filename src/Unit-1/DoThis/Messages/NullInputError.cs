namespace WinTail.Messages
{
    public partial class Message
    {
        public class NullInputError : InputError
        {
            public NullInputError(string reason) : base(reason)
            {

            }
        }
    }
}
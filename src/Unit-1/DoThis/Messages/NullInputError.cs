namespace WinTail.MessagesNs
{
    public partial class Messages
    {
        public class NullInputError : InputError
        {
            public NullInputError(string reason) : base(reason)
            {

            }
        }
    }
}
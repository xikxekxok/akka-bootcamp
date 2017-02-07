namespace WinTail.MessagesNs
{
    public partial class Messages
    {
        public class ValidationInputError : InputError
        {
            public ValidationInputError(string reason) : base(reason)
            {

            }
        }
    }
}
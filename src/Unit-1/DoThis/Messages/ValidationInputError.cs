namespace WinTail.Messages
{
    public partial class Message
    {
        public class ValidationInputError : InputError
        {
            public ValidationInputError(string reason) : base(reason)
            {

            }
        }
    }
}
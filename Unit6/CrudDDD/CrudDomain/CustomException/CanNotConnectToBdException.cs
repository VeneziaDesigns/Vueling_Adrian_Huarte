namespace CrudDomain.CustomException
{
    public class CanNotConnectToBdException : Exception
    {
        public CanNotConnectToBdException(string message) : base(message) { }

        public CanNotConnectToBdException()
        {

        }
    }
}


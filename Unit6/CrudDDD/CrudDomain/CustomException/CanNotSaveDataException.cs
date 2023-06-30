namespace CrudDomain.CustomException
{
    public class CanNotSaveDataException : Exception
    {
        public CanNotSaveDataException(string message) : base(message) { }

        public CanNotSaveDataException()
        {

        }
    }
}

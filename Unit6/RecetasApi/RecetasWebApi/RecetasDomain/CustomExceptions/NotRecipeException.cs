namespace RecetasDomain.CustomExceptions
{
    public class NotRecipeException : Exception
    {
        public NotRecipeException(string message) : base(message) { }

        public NotRecipeException()
        {
        }
    }
}

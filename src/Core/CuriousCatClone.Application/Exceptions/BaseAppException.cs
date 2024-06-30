namespace CuriousCatClone.Application.Exceptions
{
    public class BaseAppException : Exception
    {
        public IEnumerable<string> errors = new List<string>();

        public BaseAppException(string errorMessage) : base(errorMessage)
        {
            
        }

        public BaseAppException(string errorMessage, IEnumerable<string> errors) : base(errorMessage)
        {
            this.errors = errors;
        }
    }
}

namespace CuriousCatClone.Application.Exceptions
{
    public class UserCreateException : BaseAppException
    {
        public UserCreateException(string errorMessage, IEnumerable<string> errors)
            : base(errorMessage, errors)
        {

        }
    }
}

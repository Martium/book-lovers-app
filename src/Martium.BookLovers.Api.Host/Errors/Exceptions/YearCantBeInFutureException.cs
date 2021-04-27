namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class YearCantBeInFutureException : BadRequestException
    {
        public YearCantBeInFutureException() : base("YearCantBeInFuture", "Year can not be in Future")
        {
            
        }
    }
}

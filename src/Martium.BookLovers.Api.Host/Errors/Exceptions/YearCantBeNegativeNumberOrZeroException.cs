namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class YearCantBeNegativeNumberOrZeroException : BadRequestException
    {
        public YearCantBeNegativeNumberOrZeroException() : base("YearCantBeNegativeNumberOrZero", "Year can not be negative number or zero")
        {
            
        }
    }
}

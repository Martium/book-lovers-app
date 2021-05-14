namespace Martium.BookLovers.Web.Enums
{
    public enum ErrorsTypes
    {
        AuthorIdMustBeProvided,
        BookIdMustBeProvided,
        BadAuthorId,
        ThereIsNoAuthors,
        TextMustBeInteger,
        AuthorFirstNameMustBeProvided,
        AuthorLastNameMustBeProvided,
        BookNotFound,
        BookNameMustBeProvided,
        YearMustBeProvided,
        AuthorWasNotUpdated,
        AuthorWasDeletedBeforeOrNotExitsAtAll,
        NewBookWasNotCreated,
        BookWasNotUpdated,
        NewAuthorWasNotCreated,
        BookWasDeletedBeforeOrNotExitsAtAll
    }
}

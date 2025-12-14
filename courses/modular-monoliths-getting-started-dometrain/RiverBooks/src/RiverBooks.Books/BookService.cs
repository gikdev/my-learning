namespace RiverBooks.Books;

internal class BookService : IBookService {
    public List<BookDto> ListBooks()
    => [
        new BookDto(Guid.NewGuid(), "The Fellowship of the Ring", "J.R.R. Tokien"),
        new BookDto(Guid.NewGuid(), "The Two Towers", "J.R.R. Tokien"),
        new BookDto(Guid.NewGuid(), "The Return of the King", "J.R.R. Tokien"),
    ];
}

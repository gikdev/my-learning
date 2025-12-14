namespace RiverBooks.Books;

internal class BookService(IBookRepository bookRepository) : IBookService {
    public async Task<List<BookDto>> ListBooksAsync() {
        var books = await bookRepository.ListAsync();
        var items = books.Select(b => new BookDto(b.Id, b.Title, b.Author, b.Price)).ToList();
        return items;
    }

    public async Task<BookDto> GetBookByIdAsync(Guid id) {
        var book = await bookRepository.GetByIdAsync(id);

        // TODO: handle not found case

        return new BookDto(book!.Id, book.Title, book.Author, book.Price);
    }

    public async Task CreateBookAsync(BookDto newBook) {
        var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);
        await bookRepository.AddAsync(book);
        await bookRepository.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid id) {
        var bookToDelete = await bookRepository.GetByIdAsync(id);

        if (bookToDelete is not null) {
            await bookRepository.DeleteAsync(bookToDelete);
            await bookRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateBookPriceAsync(Guid bookId, decimal newPrice) {
        // validate the price

        var book = await bookRepository.GetByIdAsync(bookId);

        // handle case for not found

        book!.UpdatePrice(newPrice);
        await bookRepository.SaveChangesAsync();
    }
}

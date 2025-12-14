using FastEndpoints;

namespace RiverBooks.Books;

internal class ListBooksEndpoint(IBookService bookService)
    : Ep.NoReq.Res<ListBooksResponse> {
    public override void Configure() {
        Get("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct = default) {
        var books = bookService.ListBooks();
        var response = new ListBooksResponse { Books = books };
        await Send.OkAsync(response, ct);
    }
}

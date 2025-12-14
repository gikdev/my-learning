using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book> {
    internal static readonly Guid Book1Guid = new("D13E937C-0761-4BA8-A871-E1D6125B1BCB");
    internal static readonly Guid Book2Guid = new("3CABB713-D7B2-4B08-8162-CC1B01ED9695");
    internal static readonly Guid Book3Guid = new("03F6F9D7-B676-4C6F-9B97-170DCD0B0CCB");

    public void Configure(EntityTypeBuilder<Book> builder) {
        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DefaultNameLength)
            .IsRequired();

        builder.Property(p => p.Author)
            .HasMaxLength(DataSchemaConstants.DefaultNameLength)
            .IsRequired();

        builder.HasData(GetSamleBookData());
    }

    private IEnumerable<Book> GetSamleBookData() {
        const string tolkien = "J.R.R. Tolkien";

        yield return new Book(Book1Guid, "The Fellowship of the Ring", tolkien, 10.99m);
        yield return new Book(Book2Guid, "The Two Towers", tolkien, 11.99m);
        yield return new Book(Book3Guid, "The Return of the King", tolkien, 12.99m);
    }
}

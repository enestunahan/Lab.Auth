using Lab.Auth.Domain.Common;

namespace Lab.Auth.Domain;

public sealed class BookAuthor : BaseEntity
{
    public Guid BookId { get; set; }
    public Book? Book { get; set; }

    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
}
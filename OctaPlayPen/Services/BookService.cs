namespace OctaPlayPen.Services;

public class BookService
{
    private readonly List<string> _books = new List<string>();

    public void AddBooks(string book)
    {
        _books.Add(book);
    }

    public List<string> GetBooks()
    {
        return _books;
    }
}
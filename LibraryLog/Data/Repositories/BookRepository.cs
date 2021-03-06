using LibraryLog.Models;

namespace LibraryLog.Data.Repositories
{
    public class BookRepository : ICrudRepository<Book, int>
    {
        private readonly BookContext _BookContext;
        public BookRepository(BookContext BookContext)
        {
            _BookContext = BookContext ?? throw new
            ArgumentNullException(nameof(BookContext));
        }
        public void Add(Book element)
        {
            _BookContext.Books.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _BookContext.Books.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _BookContext.Books.Any(u => u.Id == id);
        }
        public Book Get(int id)
        {
            return _BookContext.Books.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Book> GetAll()
        {
            return _BookContext.Books.ToList();
        }

        public IEnumerable<string> GetJoinedData()
        {
            List<Book> bookz = _BookContext.Books.ToList();
            List<Author> authorz = _BookContext.Authors.ToList();

            var result = from book in bookz
                         join author in authorz
                         on book.AuthorId equals author.AuthorId
                         select $"Title: {book.Title} , Author Name:{author.Name}";
            return result;

        }

        public bool Save()
        {
            return _BookContext.SaveChanges() > 0;
        }
        public void Update(Book element)
        {
            _BookContext.Update(element);
        }
    }

}

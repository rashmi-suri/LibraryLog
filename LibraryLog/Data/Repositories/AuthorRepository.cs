using LibraryLog.Data;
using LibraryLog.Data.Repositories;
using LibraryLog.Models;

public class AuthorRepository : ICrudRepository<Author, int>
{
    private readonly BookContext _BookContext;
    public AuthorRepository(BookContext BookContext)
    {
        _BookContext = BookContext ?? throw new
        ArgumentNullException(nameof(BookContext));
    }
    public void Add(Author element)
    {
        _BookContext.Authors.Add(element);
    }
    public void Delete(int id)
    {
        var item = Get(id);
        if (item is not null) _BookContext.Authors.Remove(Get(id));
    }
    public bool Exists(int id)
    {
        return _BookContext.Authors.Any(u => u.AuthorId == id);
    }
    public Author Get(int id)
    {
        return _BookContext.Authors.FirstOrDefault(u => u.AuthorId == id);
    }
    public IEnumerable<Author> GetAll()
    {
        return _BookContext.Authors.ToList();
    }
    public bool Save()
    {
        return _BookContext.SaveChanges() > 0;
    }
    public void Update(Author element)
    {
        _BookContext.Update(element);
    }
}


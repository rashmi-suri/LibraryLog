using LibraryLog.Data.Repositories;
using LibraryLog.Models;
using LibraryLog.Services;

public class AuthorService : ICrudService<Author, int>
{
    private readonly ICrudRepository<Author, int> _AuthorRepository;
    public AuthorService(ICrudRepository<Author, int> AuthorRepository)
    {
        _AuthorRepository = AuthorRepository;
    }
    public void Add(Author element)
    {
        _AuthorRepository.Add(element);
        _AuthorRepository.Save();
    }
    public void Delete(int id)
    {
        _AuthorRepository.Delete(id);
        _AuthorRepository.Save();
    }
    public Author Get(int id)
    {
        return _AuthorRepository.Get(id);
    }
    public IEnumerable<Author> GetAll()
    {
        return _AuthorRepository.GetAll();
    }
    public void Update(Author old, Author newT)
    {
        old.PhoneNumb = newT.PhoneNumb;
        old.Email = newT.Email;
        _AuthorRepository.Update(old);
        _AuthorRepository.Save();
    }
}

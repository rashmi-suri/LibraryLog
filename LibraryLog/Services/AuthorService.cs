using LibraryLog.Data.Repositories;
using LibraryLog.Models;

namespace LibraryLog.Services
{
    public class AuthorService : ICrudService<Book, int>
    {
        private readonly ICrudRepository<Book, int> _AuthorRepository;
        public AuthorService(ICrudRepository<Book, int> BookRepository)
        {
            _AuthorRepository = BookRepository;
        }
        public void Add(Book element)
        {
            _AuthorRepository.Add(element);
            _AuthorRepository.Save();
        }
        public void Delete(int id)
        {
            _AuthorRepository.Delete(id);
            _AuthorRepository.Save();
        }
        public Book Get(int id)
        {
            return _AuthorRepository.Get(id);
        }
        public IEnumerable<Book> GetAll()
        {
            return _AuthorRepository.GetAll();
        }
        public void Update(Book old, Book newT)
        {
            old.Description = newT.Description;
            old.Status = newT.Status;
            _AuthorRepository.Update(old);
            _AuthorRepository.Save();
        }
    }

}
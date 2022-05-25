using LibraryLog.Data.Repositories;
using LibraryLog.Models;

namespace LibraryLog.Services
{
    public class BookService : ICrudService<Book, int>
    {
        private readonly ICrudRepository<Book, int> _BookRepository;
        public BookService(ICrudRepository<Book, int> BookRepository)
        {
            _BookRepository = BookRepository;
        }
        public void Add(Book element)
        {
            _BookRepository.Add(element);
            _BookRepository.Save();
        }
        public void Delete(int id)
        {
            _BookRepository.Delete(id);
            _BookRepository.Save();
        }
        public Book Get(int id)
        {
            return _BookRepository.Get(id);
        }
        public IEnumerable<Book> GetAll()
        {
            return _BookRepository.GetAll();
        }
        public void Update(Book old, Book newT)
        {
            old.Description = newT.Description;
            old.Status = newT.Status;
            _BookRepository.Update(old);
            _BookRepository.Save();
        }

        public IEnumerable<string> GetJoinedData()
        {
            return ((BookRepository)_BookRepository).GetJoinedData();
        }
    }

}

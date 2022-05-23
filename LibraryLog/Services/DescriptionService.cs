using LibraryLog.Data.Repositories;
using LibraryLog.Models;

namespace LibraryLog.Services
{
    public class DescriptionService : ICrudService<BookDescription, int>
    {
        private readonly ICrudRepository<BookDescription, int> _DescriptionRepository;
        public DescriptionService(ICrudRepository<BookDescription, int> DescriptionRepository)
        {
            _DescriptionRepository = DescriptionRepository;
        }
        public void Add(BookDescription element)
        {
            _DescriptionRepository.Add(element);
            _DescriptionRepository.Save();
        }
        public void Delete(int id)
        {
            _DescriptionRepository.Delete(id);
            _DescriptionRepository.Save();
        }
        public BookDescription Get(int id)
        {
            return _DescriptionRepository.Get(id);
        }
        public IEnumerable<BookDescription> GetAll()
        {
            return _DescriptionRepository.GetAll();
        }
        public void Update(BookDescription old, BookDescription newT)
        {
            old.Description = newT.Description;
            old.Status = newT.Status;
            _DescriptionRepository.Update(old);
            _DescriptionRepository.Save();
        }
    }

}

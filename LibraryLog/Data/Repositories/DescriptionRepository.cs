using LibraryLog.Models;

namespace LibraryLog.Data.Repositories
{
    public class DescriptionRepository : ICrudRepository<BookDescription, int>
    {
        private readonly DescriptionContext _DescriptionContext;
        public DescriptionRepository(DescriptionContext DescriptionContext)
        {
            _DescriptionContext = DescriptionContext ?? throw new
            ArgumentNullException(nameof(DescriptionContext));
        }
        public void Add(BookDescription element)
        {
            _DescriptionContext.BookDescriptions.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _DescriptionContext.BookDescriptions.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _DescriptionContext.BookDescriptions.Any(u => u.Id == id);
        }
        public BookDescription Get(int id)
        {
            return _DescriptionContext.BookDescriptions.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<BookDescription> GetAll()
        {
            return _DescriptionContext.BookDescriptions.ToList();
        }
        public bool Save()
        {
            return _DescriptionContext.SaveChanges() > 0;
        }
        public void Update(BookDescription element)
        {
            _DescriptionContext.Update(element);
        }
    }

}

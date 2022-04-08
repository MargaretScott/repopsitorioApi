using BootcampAres.DataAccess.Contracts;

namespace BootcampAres.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private BootcampAresContext _context;

        public UnitOfWork(BootcampAresContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

using Auth.Domain.Interfaces;
using Auth.Infrastructure.Data.Context;

namespace Auth.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository _userRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _userRepository = new UserRepository(context);
        }
        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }
        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
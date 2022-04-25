
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Spesifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class EFRepository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
{
    private readonly IDbContextFactory<ShipContext> _contextFactory;
    public  EFRepository(IDbContextFactory<ShipContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
   
    public virtual async Task<T> GetByIdAsync(int id)
        {
             using var _dbContext =_contextFactory.CreateDbContext();
            return await _dbContext.Set<T>().FindAsync(id);
        }
        
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
             using var _dbContext =_contextFactory.CreateDbContext();
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
              using var _dbContext =_contextFactory.CreateDbContext();
            return await ApplySpecification(_dbContext,spec).ToListAsync();
        }
        
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
               using var _dbContext =_contextFactory.CreateDbContext();
            return await ApplySpecification(_dbContext,spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
             using var _dbContext =_contextFactory.CreateDbContext();
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        
        public async Task UpdateAsync(T entity)
        {
             using var _dbContext =_contextFactory.CreateDbContext();
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(T entity)
        {
             using var _dbContext =_contextFactory.CreateDbContext();
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

          public async Task<IEnumerable<T>> GetBySpesification(BaseSpecification<T> spec)
        {
              using var _dbContext =_contextFactory.CreateDbContext();
            return await ApplySpecification(_dbContext,spec).ToListAsync();
        }
        
        private IQueryable<T> ApplySpecification(DbContext _dbContext,ISpecification<T> spec)
        {
           
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

  
}
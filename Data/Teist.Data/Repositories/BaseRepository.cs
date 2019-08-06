namespace Teist.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Teist.Data.Common.Models;
    using Teist.Data.Common.Repositories;

    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseDeletableModel<int>
    {
        private TeistDbContext data;

        public BaseRepository(TeistDbContext data)
        {
            this.data = data;
        }

        public void Add(TEntity entity)
        {
            data.Add(entity);
        }

        public IQueryable<TEntity> All()
        {
            return data.Set<TEntity>();
        }

        public IQueryable<TEntity> AllAsNoTracking()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            data.Remove(entity);
            // TODO: Deletables

        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(params object[] id)
        {
            return data.Set<TEntity>().FindAsync(id);
        }

        public Task<int> SaveChangesAsync()
        {
            return data.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

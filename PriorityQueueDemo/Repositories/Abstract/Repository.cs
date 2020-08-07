using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriorityQueueDemo.Contexts;
using PriorityQueueDemo.Models.Interfaces;
using PriorityQueueDemo.Repositories.Interfaces.Abstract;

namespace PriorityQueueDemo.Repositories.Abstract
{
    /// <summary>
    /// Generic Repository for all entities
    /// </summary>
    /// <typeparam name="T">The entity</typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Inject context inside constructor
        /// </summary>
        /// <param name="priorityQueueDbContext"></param>
        protected Repository(PriorityQueueDbContext priorityQueueDbContext)
        {
            PriorityQueueDbContext = priorityQueueDbContext;
        }

        /// <summary>
        /// The DB context
        /// </summary>
        protected PriorityQueueDbContext PriorityQueueDbContext { get; set; }

        /// <summary>
        /// Get all Ts
        /// </summary>
        /// <returns>All Ts</returns>
        public virtual IQueryable<T> FindAll()
        {
            return PriorityQueueDbContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Get one T by Id
        /// </summary>
        /// <param name="id">The requested id</param>
        /// <returns>T</returns>
        public virtual T FindById(int id)
        {
            return PriorityQueueDbContext.Set<T>().AsNoTracking().ToList().FirstOrDefault(x => x.GetId().Equals(id));
        }

        /// <summary>
        /// Create the T
        /// </summary>
        /// <param name="model">The T model</param>
        /// <returns>T</returns>
        public virtual async Task<T> Create(T model)
        {
            var entityEntry = PriorityQueueDbContext.Add(model);

            var saveResult = await PriorityQueueDbContext.SaveChangesAsync();

            if (saveResult > 0)
            {
                entityEntry.State = EntityState.Detached;

                return FindById(entityEntry.Entity.GetId());
            }

            entityEntry.State = EntityState.Detached;

            return null;
        }

        /// <summary>
        /// Update the T
        /// </summary>
        /// <param name="model">The T model</param>
        /// <returns>T</returns>
        public virtual async Task<T> Update(T model)
        {
            var entityEntry = PriorityQueueDbContext.Update(model);

            var updateResult = await PriorityQueueDbContext.SaveChangesAsync();

            if (updateResult > 0)
            {
                entityEntry.State = EntityState.Detached;

                return FindById(entityEntry.Entity.GetId());
            }

            entityEntry.State = EntityState.Detached;

            return null;
        }

        /// <summary>
        /// Delete the T
        /// </summary>
        /// <param name="model">The T model</param>
        /// <returns>T</returns>
        public virtual async Task<T> Delete(T model)
        {
            var entityEntry = PriorityQueueDbContext.Remove(model);

            var deleteResult = await PriorityQueueDbContext.SaveChangesAsync();

            if (deleteResult > 0)
            {
                entityEntry.State = EntityState.Detached;

                return entityEntry.Entity;
            }

            entityEntry.State = EntityState.Detached;

            return null;
        }
    }
}
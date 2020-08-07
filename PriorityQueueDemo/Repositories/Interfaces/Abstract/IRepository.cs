using System.Linq;
using System.Threading.Tasks;

namespace PriorityQueueDemo.Repositories.Interfaces.Abstract
{
    // <summary>
    /// Generic Repository Interface
    /// </summary>
    /// <typeparam name="T">The Entity of the repository</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get all Ts
        /// </summary>
        /// <returns>All Ts</returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Get one T by Id
        /// </summary>
        /// <param name="id">The requested id</param>
        /// <returns>T</returns>
        T FindById(int id);

        /// <summary>
        /// Create the T
        /// </summary>
        /// <param name="model">The T model</param>
        /// <returns>T</returns>
        Task<T> Create(T model);

        /// <summary>
        /// Update the T
        /// </summary>
        /// <param name="model">The T model</param>
        /// <returns>T</returns>
        Task<T> Update(T model);

        /// <summary>
        /// Delete the T
        /// </summary>
        /// <param name="model">The T model</param>
        /// <returns>T</returns>
        Task<T> Delete(T model);
    }
}
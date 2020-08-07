using System.Collections.Generic;

namespace PriorityQueueDemo.Services.Interfaces.Abstract
{
    /// <summary>
    /// Generic Service Interface
    /// </summary>
    public interface IService<T>
    {
        /// <summary>
        /// Find all the T entities
        /// </summary>
        /// <returns>All the T entities</returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// Find the T entity with a specific id
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <returns>T entity</returns>
        T FindById(int id);

        /// <summary>
        /// Create the T entity
        /// </summary>
        /// <param name="model">T model as entity</param>
        /// <returns>The created entity</returns>
        T Create(T model);

        /// <summary>
        /// Update the T entity
        /// </summary>
        /// <param name="model">T model as entity</param>
        /// <returns>The updated entity</returns>
        T Update(T model);

        /// <summary>
        /// Delete the T entity
        /// </summary>
        /// <param name="model">T model as entity</param>
        /// <returns>The deleted entity</returns>
        T Delete(T model);
    }
}
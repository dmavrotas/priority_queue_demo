using System.Collections.Generic;
using System.Linq;
using PriorityQueueDemo.Repositories.Interfaces.Abstract;
using PriorityQueueDemo.Services.Interfaces.Abstract;

namespace PriorityQueueDemo.Services.Abstract
{
    /// <summary>
    /// Abstract service to be used by the entities
    /// </summary>
    /// <typeparam name="T">An entity T</typeparam>
    public abstract class Service<T> : IService<T> where T : class
    {
        /// <summary>
        /// Abstract Repository
        /// </summary>
        private readonly IRepository<T> _repository;

        /// <summary>
        /// Repository injection from the constructor
        /// </summary>
        /// <param name="repository">Repository Injection</param>
        protected Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Find all the T entities
        /// </summary>
        /// <returns>All the T entities</returns>
        public virtual IEnumerable<T> FindAll()
        {
            return _repository.FindAll().ToList();
        }

        /// <summary>
        /// Find the T entity with a specific id
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <returns>T entity</returns>
        public virtual T FindById(int id)
        {
            return _repository.FindById(id);
        }

        /// <summary>
        /// Create the T entity
        /// </summary>
        /// <param name="model">T model as entity</param>
        /// <returns>The created entity</returns>
        public virtual T Create(T model)
        {
            return _repository.Create(model).Result;
        }

        /// <summary>
        /// Update the T entity
        /// </summary>
        /// <param name="model">T model as entity</param>
        /// <returns>The updated entity</returns>
        public virtual T Update(T model)
        {
            return _repository.Update(model).Result;
        }

        /// <summary>
        /// Delete the T entity
        /// </summary>
        /// <param name="model">T model as entity</param>
        /// <returns>The deleted entity</returns>
        public virtual T Delete(T model)
        {
            return _repository.Delete(model).Result;
        }
    }
}
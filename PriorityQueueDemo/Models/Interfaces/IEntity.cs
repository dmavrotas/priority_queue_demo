namespace PriorityQueueDemo.Models.Interfaces
{
    /// <summary>
    /// Interface to be used by entities we want to make queries on
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Get the entity id (the entity must return an id)
        /// </summary>
        /// <returns>The Entity Id</returns>
        int GetId();
    }
}
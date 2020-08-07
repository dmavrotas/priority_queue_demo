using PriorityQueueDemo.Contexts;
using PriorityQueueDemo.Models;
using PriorityQueueDemo.Repositories.Abstract;
using PriorityQueueDemo.Repositories.Interfaces;

namespace PriorityQueueDemo.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class QueueTypeRepository : Repository<QueueType>, IQueueTypeRepository
    {
        public QueueTypeRepository(PriorityQueueDbContext priorityQueueDbContext) : base(priorityQueueDbContext)
        {
        }
    }
}
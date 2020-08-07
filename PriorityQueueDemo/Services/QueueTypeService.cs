using PriorityQueueDemo.Models;
using PriorityQueueDemo.Repositories.Interfaces;
using PriorityQueueDemo.Services.Abstract;
using PriorityQueueDemo.Services.Interfaces;

namespace PriorityQueueDemo.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class QueueTypeService : Service<QueueType>, IQueueTypeService
    {
        private IQueueTypeRepository _queueTypeRepository;

        public QueueTypeService(IQueueTypeRepository queueTypeRepository) : base(queueTypeRepository)
        {
            _queueTypeRepository = queueTypeRepository;
        }
    }
}
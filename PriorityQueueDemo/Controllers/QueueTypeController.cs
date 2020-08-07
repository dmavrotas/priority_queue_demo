using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PriorityQueueDemo.Controllers.Abstract;
using PriorityQueueDemo.Misc;
using PriorityQueueDemo.Models;
using PriorityQueueDemo.Services.Interfaces;

namespace PriorityQueueDemo.Controllers
{
    /// <summary>
    /// Controller for QueueType Entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QueueTypeController : GenericController<QueueType>
    {
        /// <summary>
        /// 
        /// </summary>
        private IQueueTypeService _queueTypeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queueTypeService"></param>
        public QueueTypeController(IQueueTypeService queueTypeService)
        {
            _queueTypeService = queueTypeService;
        }

        /// <summary>
        /// GET api/queue
        /// </summary>
        /// <returns>All applications</returns>
        [HttpGet]
        public ActionResult<KResponse<QueueType>> Get()
        {
            return GetResponse(() => _queueTypeService.FindAll().ToList());
        }

        /// <summary>
        /// GET api/queue/{id}
        /// </summary>
        /// <param name="id">QueueType Id</param>
        /// <returns>The QueueType requested</returns>
        [HttpGet("{id}")]
        public ActionResult<KResponse<QueueType>> Get(int id)
        {
            return GetResponse(() => _queueTypeService.FindById(id));
        }

        /// <summary>
        /// POST api/queue
        /// </summary>
        /// <param name="editedQueue">The Edited QueueType</param>
        /// <returns>The edited QueueType</returns>
        [HttpPost]
        public ActionResult<KResponse<QueueType>> Post([FromBody] QueueType editedQueueType)
        {
            return GetResponse(() => _queueTypeService.Update(editedQueueType));
        }

        /// <summary>
        /// PUT api/queue
        /// </summary>
        /// <param name="newQueueType">The new QueueType</param>
        /// <returns>The new QueueType</returns>
        [HttpPut]
        public ActionResult<KResponse<QueueType>> Put([FromBody] QueueType newQueueType)
        {
            return GetResponse(() => _queueTypeService.Create(newQueueType));
        }

        /// <summary>
        /// DELETE api/queue/{id}
        /// </summary>
        /// <param name="id">QueueType Id</param>
        /// <returns>The deleted QueueType</returns>
        [HttpDelete("{id}")]
        public ActionResult<KResponse<QueueType>> Delete(int id)
        {
            return GetResponse(() => _queueTypeService.Delete(_queueTypeService.FindById(id)));
        }
    }
}
using Microsoft.EntityFrameworkCore;
using PriorityQueueDemo.Contexts;

namespace PriorityQueueDemoTest.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryDbContextFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PriorityQueueDbContext GetPriorityQueueDbContext()
        {
            var options = new DbContextOptionsBuilder<PriorityQueueDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryPriorityQueueDb")
                .Options;

            return new PriorityQueueDbContext(options);
        }
    }
}
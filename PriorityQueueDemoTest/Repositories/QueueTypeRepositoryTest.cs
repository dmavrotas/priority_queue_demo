using System;
using System.Linq;
using PriorityQueueDemo.Contexts;
using PriorityQueueDemo.Models;
using PriorityQueueDemo.Repositories;
using PriorityQueueDemo.Repositories.Interfaces;
using PriorityQueueDemoTest.Context;
using Xunit;

namespace PriorityQueueDemoTest.Repositories
{
    [Collection("RepositoryCollection")]
    public class QueueTypeRepositoryTest : IDisposable
    {
        public QueueTypeRepositoryTest()
        {
            _context = new InMemoryDbContextFactory().GetPriorityQueueDbContext();
            _context.QueueType.RemoveRange(_context.QueueType);
            _queueTypeRepository = new QueueTypeRepository(_context);
        }
        
        public void Dispose()
        {
            _context.QueueType.RemoveRange(_context.QueueType);
            _context.SaveChanges();
        }
        
        private readonly IQueueTypeRepository _queueTypeRepository;

        private readonly PriorityQueueDbContext _context;

        [Fact]
        private void TestCreate()
        {
            var now = DateTime.Now;
            
            var queueType = new QueueType
            {
                Name = "My Queue Type",
                Delay = 1,
                Duration = 5,
                Created = now
            };

            var created = _queueTypeRepository.Create(queueType).Result;
            
            Assert.Equal(created.Id, _queueTypeRepository.FindById(created.Id).Id);
            Assert.NotNull(created);
            Assert.Equal(created.Id, queueType.Id);
        }

        [Fact]
        private void TestUpdate()
        {
            var now = DateTime.Now;
            
            var queueType = new QueueType
            {
                Name = "My Queue Type 2",
                Delay = 4,
                Duration = 6,
                Created = now
            };

            var created = _queueTypeRepository.Create(queueType).Result;
            
            Assert.Equal(created.Id, _queueTypeRepository.FindById(created.Id).Id);
            Assert.NotNull(created);
            Assert.Equal(created.Id, queueType.Id);

            created.Name = "I just changed my mind";

            var updated = _queueTypeRepository.Update(created).Result;
            
            Assert.NotNull(updated);
            Assert.Equal("I just changed my mind", updated.Name);
        }

        [Fact]
        private void TestDelete()
        {
            var now = DateTime.Now;
            
            var queueType = new QueueType
            {
                Name = "My Queue Type 3",
                Delay = 4,
                Duration = 6,
                Created = now
            };

            var created = _queueTypeRepository.Create(queueType).Result;
            
            Assert.Equal(created.Id, _queueTypeRepository.FindById(created.Id).Id);
            Assert.NotNull(created);
            Assert.Equal(created.Id, queueType.Id);

            var deleted = _queueTypeRepository.Delete(created).Result;
            
            Assert.Null(_queueTypeRepository.FindById(deleted.Id));
        }
    }
}
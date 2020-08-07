using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using PriorityQueueDemo.Models;
using PriorityQueueDemo.Repositories.Interfaces;
using PriorityQueueDemo.Services;
using Xunit;

namespace PriorityQueueDemoTest.Services
{
    public class QueueTypeServiceTest
    {
        public QueueTypeServiceTest()
        {
            _queueTypes = new List<QueueType>();

            var queueType = new QueueType
            {
                Id = 1, Name = "A QueueType", Created = DateTime.Now, Delay = 1, Duration = 2,
                PriorityQueue = new List<PriorityQueue>()
            };

            _queueTypes.Add(queueType);

            var mock = new Mock<IQueueTypeRepository>();

            mock.Setup(x => x.FindAll()).Returns(_queueTypes.AsQueryable());
            mock.Setup(x => x.FindById(It.IsAny<int>())).Returns(queueType);
            mock.Setup(x => x.Create(It.IsAny<QueueType>())).Returns(Task.FromResult(queueType));
            mock.Setup(x => x.Update(It.IsAny<QueueType>())).Returns(Task.FromResult(queueType));
            mock.Setup(x => x.Delete(It.IsAny<QueueType>())).Returns(Task.FromResult(queueType));

            _queueTypeRepository = mock.Object;
        }

        private readonly IQueueTypeRepository _queueTypeRepository;

        private readonly List<QueueType> _queueTypes;

        [Fact]
        private void TestExceptions()
        {
            var mockException = new Mock<IQueueTypeRepository>();

            mockException.Setup(x => x.FindAll()).Throws(new Exception());
            mockException.Setup(x => x.FindById(It.IsAny<int>())).Throws(new Exception());
            mockException.Setup(x => x.Create(It.IsAny<QueueType>())).Throws(new Exception());
            mockException.Setup(x => x.Update(It.IsAny<QueueType>())).Throws(new Exception());
            mockException.Setup(x => x.Delete(It.IsAny<QueueType>())).Throws(new Exception());

            var queueTypeRepository = mockException.Object;

            var queueTypeService = new QueueTypeService(queueTypeRepository);

            Assert.Throws<Exception>(() => queueTypeService.FindAll());
            Assert.Throws<Exception>(() => queueTypeService.FindById(1));
            Assert.Throws<Exception>(() => queueTypeService.Update(new QueueType()));
            Assert.Throws<Exception>(() => queueTypeService.Create(new QueueType()));
            Assert.Throws<Exception>(() => queueTypeService.Delete(new QueueType()));
        }

        [Fact]
        private void TestFindAll()
        {
            var queueTypeService = new QueueTypeService(_queueTypeRepository);

            Assert.Equal(_queueTypes, queueTypeService.FindAll());
        }

        [Fact]
        private void TestFindById()
        {
            var queueTypeService = new QueueTypeService(_queueTypeRepository);

            Assert.Equal(_queueTypes[0], queueTypeService.FindById(1));
        }

        [Fact]
        private void TestCreate()
        {
            var queueTypeService = new QueueTypeService(_queueTypeRepository);

            Assert.Equal(_queueTypes[0], queueTypeService.Create(new QueueType()));
        }

        [Fact]
        private void TestUpdate()
        {
            var queueTypeService = new QueueTypeService(_queueTypeRepository);

            Assert.Equal(_queueTypes[0], queueTypeService.Update(new QueueType()));
        }

        [Fact]
        private void TestDelete()
        {
            var queueTypeService = new QueueTypeService(_queueTypeRepository);

            Assert.Equal(_queueTypes[0], queueTypeService.Delete(new QueueType()));
        }
    }
}
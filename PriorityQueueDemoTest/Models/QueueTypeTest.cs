using System;
using PriorityQueueDemo.Models;
using Xunit;

namespace PriorityQueueDemoTest.Models
{
    public class QueueTypeTest
    {
        [Fact]
        private void ModelTest()
        {
            var now = DateTime.Now;
            
            var queue = new QueueType
            {
                Id = 1,
                Name = "My QueueType",
                Delay = 1,
                Duration = 5,
                Created = now
            };
            
            Assert.Equal(1, queue.Id);
            Assert.Equal("My QueueType", queue.Name);
            Assert.Equal(1, queue.Delay);
            Assert.Equal(5, queue.Duration);
            Assert.Equal(now, queue.Created);
        }
    }
}
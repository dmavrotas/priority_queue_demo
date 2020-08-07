using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using PriorityQueueDemo;
using PriorityQueueDemo.Contexts;
using PriorityQueueDemo.Controllers;
using PriorityQueueDemo.Models;
using PriorityQueueDemo.Repositories;
using PriorityQueueDemo.Repositories.Interfaces;
using PriorityQueueDemo.Services;
using PriorityQueueDemo.Services.Interfaces;
using PriorityQueueDemoTest.Context;
using Xunit;

namespace PriorityQueueDemoTest.Controllers
{
    public class QueueTypeControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>, IDisposable
    {
        public QueueTypeControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _context = new InMemoryDbContextFactory().GetPriorityQueueDbContext();
            _context.QueueType.RemoveRange(_context.QueueType);
            _queueTypeRepository = new QueueTypeRepository(_context);
            _queueTypeService = new QueueTypeService(_queueTypeRepository);
            _controller = new QueueTypeController(_queueTypeService);
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        }

        public void Dispose()
        {
            _context.QueueType.RemoveRange(_context.QueueType);
            _context.SaveChanges();
        }

        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly IQueueTypeService _queueTypeService;
        private readonly IQueueTypeRepository _queueTypeRepository;
        private readonly PriorityQueueDbContext _context;
        private readonly QueueTypeController _controller;

        [Fact]
        private void TestGetAll()
        {
            var result = _controller.Get();

            Assert.NotNull(result.Value);
            Assert.Empty(result.Value.Content.Results);
        }

        [Fact]
        private void TestPut()
        {
            var queueType = new QueueType
                {Id = 1, Name = "HelloThere", Delay = 1, Duration = 6, Created = DateTime.Now};

            var putValue = _controller.Put(queueType);

            Assert.NotNull(putValue.Value);
            Assert.Equal(queueType.Id, putValue.Value.Content.Result.Id);
        }

        [Fact]
        private async void TestGetAllOverHttp()
        {
            var getValue = await _client.GetStringAsync("api/queueType");

            Assert.Equal("{\"status\":0,\"content\":{\"results\":[]}}", getValue);
        }

        [Fact]
        private async void TestPutOverHttp()
        {
            var queueType = new QueueType
                {Id = 1, Name = "HelloThere", Delay = 1, Duration = 6, Created = DateTime.Now};

            var putValue = await _client.PutAsJsonAsync("api/queueType", queueType);

            Assert.Contains(
                "{\"status\":0,\"content\":{\"result\":{\"id\":1,\"name\":\"HelloThere\",\"duration\":6,\"delay\":1",
                await putValue.Content.ReadAsStringAsync());

            var getValue = await _client.GetStringAsync("api/queueType/1");

            Assert.Contains(
                "{\"status\":0,\"content\":{\"result\":{\"id\":1,\"name\":\"HelloThere\",\"duration\":6,\"delay\":1",
                getValue);
        }
    }
}
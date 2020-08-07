using System;
using System.Collections.Generic;
using System.Net.Mime;
using PriorityQueueDemo.Enums;
using PriorityQueueDemo.Models;
using PriorityQueueDemoTest.Controllers.Abstract.Helpers;
using Xunit;

namespace PriorityQueueDemoTest.Controllers.Abstract
{
    public class GenericControllerTest
    {
        private QueueType NormalQueueType()
        {
            return new QueueType();
        }

        private List<QueueType> NormalQueueTypes()
        {
            return new List<QueueType>();
        }

        private QueueType SendException()
        {
            throw new Exception("Exception");
        }

        private List<QueueType> SendExceptionWithQueueTypeList()
        {
            throw new Exception("Another Exception");
        }

        [Fact]
        private void NormalTest()
        {
            var genericControllerTest =
                new GenericControllerTestChild<QueueType>();

            var result = genericControllerTest.GetResponse(NormalQueueType);

            Assert.Equal(EkResponseStatus.Success, result.Status);
            Assert.NotNull(result.Content);
            Assert.NotNull(result.Content.Result);
            Assert.Null(result.Content.Results);
            Assert.Null(result.Message);
            Assert.Null(result.Errors);

            var results = genericControllerTest.GetResponse(NormalQueueTypes);

            Assert.Equal(EkResponseStatus.Success, results.Status);
            Assert.NotNull(results.Content);
            Assert.Null(results.Content.Result);
            Assert.NotNull(results.Content.Results);
            Assert.Null(results.Message);
            Assert.Null(results.Errors);


            var exceptionResult = genericControllerTest.GetResponse(SendException);

            Assert.Equal(EkResponseStatus.Failure, exceptionResult.Status);
            Assert.Null(exceptionResult.Content);
            Assert.Equal("Exception", exceptionResult.Message);
            Assert.Single(exceptionResult.Errors);

            exceptionResult = genericControllerTest.GetResponse(SendExceptionWithQueueTypeList);

            Assert.Equal(EkResponseStatus.Failure, exceptionResult.Status);
            Assert.Null(exceptionResult.Content);
            Assert.Equal("Another Exception", exceptionResult.Message);
            Assert.Single(exceptionResult.Errors);
        }
    }
}
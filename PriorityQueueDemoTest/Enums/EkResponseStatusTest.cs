using PriorityQueueDemo.Enums;
using Xunit;

namespace PriorityQueueDemoTest.Enums
{
    public class EkResponseStatusTest
    {
        [Fact]
        private void NormalTest()
        {
            var responseStatus = EkResponseStatus.Success;

            Assert.Equal(EkResponseStatus.Success, responseStatus);

            responseStatus = EkResponseStatus.Failure;

            Assert.Equal(EkResponseStatus.Failure, responseStatus);
        }
    }
}
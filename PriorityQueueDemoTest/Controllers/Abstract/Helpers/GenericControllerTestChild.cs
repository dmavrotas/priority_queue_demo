using System;
using System.Collections.Generic;
using PriorityQueueDemo.Controllers.Abstract;
using PriorityQueueDemo.Misc;

namespace PriorityQueueDemoTest.Controllers.Abstract.Helpers
{
    public class GenericControllerTestChild<T> : GenericController<T> where T : class
    {
        public KResponse<T> GetResponse(Func<T> apiMethod)
        {
            return base.GetResponse(apiMethod);
        }

        public KResponse<T> GetResponse(Func<List<T>> apiMethod)
        {
            return base.GetResponse(apiMethod);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PriorityQueueDemo.Enums;
using PriorityQueueDemo.Misc;
using Serilog;

namespace PriorityQueueDemo.Controllers.Abstract
{
    /// <summary>
    /// Generic controller which helps the API be in the correct response format
    /// </summary>
    public abstract class GenericController<T> : ControllerBase where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiMethod"></param>
        /// <returns></returns>
        protected KResponse<long> Count(Func<long> apiMethod)
        {
            var response = new KResponse<long>();

            try
            {
                response.Status = EkResponseStatus.Success;
                response.Content = new KContent<long> { Result = apiMethod.Invoke() };
            }
            catch (Exception e)
            {
                HandleException(response, e);
            }

            return response;
        }

        /// <summary>
        /// Get a single response
        /// </summary>
        /// <param name="apiMethod">The function that produces the result</param>
        /// <returns>The response with the result</returns>
        protected KResponse<T> GetResponse(Func<T> apiMethod)
        {
            var response = new KResponse<T>();

            try
            {
                response.Status = EkResponseStatus.Success;
                response.Content = new KContent<T> { Result = apiMethod.Invoke() };
            }
            catch (Exception e)
            {
                HandleException(response, e);
            }

            return response;
        }

        /// <summary>
        /// Get a response with a list
        /// </summary>
        /// <param name="apiMethod">The function that produces the results</param>
        /// <returns>The response with the results</returns>
        protected KResponse<T> GetResponse(Func<List<T>> apiMethod)
        {
            var response = new KResponse<T>();

            try
            {
                response.Status = EkResponseStatus.Success;
                response.Content = new KContent<T> { Results = apiMethod.Invoke() };
            }
            catch (Exception e)
            {
                HandleException(response, e);
            }

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="e"></param>
        private void HandleException(KResponse<T> response, Exception e)
        {
            response.Status = EkResponseStatus.Failure;
            response.Message = e.Message;
            response.Errors = new List<string> { e.Message };

            if (e.InnerException != null)
            {
                response.Errors = response.Errors.Append(e.InnerException.Message);
            }

            Log.Logger.Error($"An error has occured : {e.Message} - {e.InnerException?.Message}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="e"></param>
        private void HandleException(KResponse<long> response, Exception e)
        {
            response.Status = EkResponseStatus.Failure;
            response.Message = e.Message;
            response.Errors = new List<string> { e.Message };

            if (e.InnerException != null)
            {
                response.Errors = response.Errors.Append(e.InnerException.Message);
            }

            Log.Logger.Error($"An error has occured : {e.Message} - {e.InnerException?.Message}");
        }
    }
}

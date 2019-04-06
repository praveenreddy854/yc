using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace YC.UIUtils
{
    public class YCJsonResult : JsonResult
    {
        YCJsonResponse response = new YCJsonResponse();
        bool retry;
        HttpStatusCode? statusCode;

        public YCJsonResult(object data, string message, bool isErroredOut = false)
        {
            response.Data = data;
            response.Message = message;
            response.IsErroredOut = isErroredOut;
        }

        public YCJsonResult(object data, bool isErroredOut = false)
        {
            response.Data = data;
            response.IsErroredOut = isErroredOut;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "context can't be null");
            }
            HttpResponseBase httpResponse = context.HttpContext.Response;
            httpResponse.TrySkipIisCustomErrors = true;

            var jsonSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            
            if (this.retry)
            {
                httpResponse.StatusCode = (int)HttpStatusCode.Conflict;
            }
            else if (this.statusCode.HasValue)
            {
                httpResponse.StatusCode = (int)this.statusCode;
            }

            httpResponse.Write(JsonConvert.SerializeObject(this.response, jsonSettings));
        }
    }

    public class YCJsonResponse
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool IsErroredOut { get; set; }
    }
}
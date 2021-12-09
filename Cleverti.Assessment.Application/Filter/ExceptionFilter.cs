using Cleverti.Assessment.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net;

namespace Cleverti.Assessment.Application.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var stackTrace = $@"{exception.Message} 
                                \nStackTrace: {exception.StackTrace} 
                                \nInnerException: {(exception.InnerException != null ? exception.InnerException.StackTrace
                                                                                     : string.Empty)}";

            var notifications = JsonConvert.SerializeObject(new
            {
                code = HttpStatusCode.InternalServerError,
                erros = new List<Notification>() {
                    new Notification("Erro", "Não foi possível completar a ação. Tente novamente mais tarde.", stackTrace)
                }
            }, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            context.Result = new ContentResult
            {
                Content = notifications,
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ContentType = "application/json"
            };
        }
    }
}

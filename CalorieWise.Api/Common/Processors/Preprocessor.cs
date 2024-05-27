using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace CalorieWise.Api.Common.Processors
{
    public class RequestLogger : IGlobalPreProcessor
    {
        public Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
        {
            var logger = context.HttpContext.Resolve<ILogger<IPreProcessorContext>>();

            logger.LogInformation($"{DateTime.Now:MM/dd/yyyy H:mm:ss.fff} - Request: {context.Request.GetType().FullName} path: {context.HttpContext.Request.Path}");

            return Task.CompletedTask;
        }
    }
}

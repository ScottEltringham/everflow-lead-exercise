using Microsoft.Extensions.Logging.Configuration;
using System.Net;

namespace CalorieWise.Api.Common.Processors
{
    public class ExceptionProcessor : IGlobalPostProcessor
    {
        public async Task PostProcessAsync(IPostProcessorContext context, CancellationToken ct)
        {

            if (!context.HasExceptionOccurred || context.HttpContext.Response.StatusCode == (int)HttpStatusCode.OK)
                return;

            if (context.HttpContext.Response.StatusCode != (int)HttpStatusCode.BadRequest)
            {
                var logger = context.HttpContext.Resolve<ILogger<IPreProcessorContext>>();

                logger.LogInformation($"{DateTime.Now:MM/dd/yyyy H:mm:ss.fff} - An unhandled exception occurred: {context.ExceptionDispatchInfo.SourceException.Message}");

                var response = new
                {
                    Message = "An unexpected error occurred. Please try again later.",
                    Error = context.ExceptionDispatchInfo.SourceException.Message
                };

                context.MarkExceptionAsHandled();
                await context.HttpContext.Response.SendAsync(response, (int)HttpStatusCode.InternalServerError);

                return;
            }

            return;
        }
    }
}

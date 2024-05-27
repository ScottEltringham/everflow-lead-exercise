using Microsoft.Extensions.Logging.Configuration;

namespace CalorieWise.Api.Common.Processors
{
    public class ExceptionProcessor : IGlobalPostProcessor
    {
        public async Task PostProcessAsync(IPostProcessorContext context, CancellationToken ct)
        {

            if (!context.HasExceptionOccurred)
                return;

            var logger = context.HttpContext.Resolve<ILogger<IPreProcessorContext>>();

            logger.LogInformation($"{DateTime.Now:MM/dd/yyyy H:mm:ss.fff} - An unhandled exception occurred: {context.ExceptionDispatchInfo.SourceException.Message}");

            var response = new
            {
                Message = "An unexpected error occurred. Please try again later.",
                Error = context.ExceptionDispatchInfo.SourceException.Message
            };

            context.MarkExceptionAsHandled();
            await context.HttpContext.Response.SendAsync(response, 500);

            return;
        }
    }
}

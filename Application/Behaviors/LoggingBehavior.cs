using MediatR;
using Serilog;
using System.Text.Json;

namespace Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = request.GetType().Name;
            var requestGuid = Guid.NewGuid().ToString();

            var requestNameWithGuid = $"{requestName} [{requestGuid}]";

            Log.Information($"[START] {requestNameWithGuid}");
            TResponse response;

            try
            {
                try
                {
                    Log.Information($"[PROPS] {requestNameWithGuid} {JsonSerializer.Serialize(request)}");
                }
                catch (NotSupportedException)
                {
                    // catching any serialization errors
                    Log.Information($"[Serialization ERROR] {requestNameWithGuid} Could not serialize the request.");
                }

                // if any errors happen, ExceptionHandler will take care of it
                response = await next();
            }
            finally
            {
                Log.Information($"[END] {requestNameWithGuid}");
            }

           return response;
        }
    }
}

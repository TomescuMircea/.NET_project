using Domain.Common;
using FluentValidation;
using MediatR;
using System.Text.Json;

namespace Application.Utils
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                var failuresString = string.Join(", ", failures);
                var errorText = JsonSerializer.Serialize(failures);

                if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var resultType = typeof(TResponse).GetGenericArguments()[0];
                    var failureResult = typeof(Result<>).MakeGenericType(resultType)
                        .GetMethod("Failure", new[] { typeof(string) })
                        .Invoke(null, new object[] { failuresString });

                    return (TResponse)failureResult;
                }

                //throw new ValidationException(failures);
            }

            return await next();
        }
    }
}

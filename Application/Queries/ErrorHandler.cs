using MediatR;

namespace Application.Queries
{
    /// <summary>
    /// This is a testing handler to see how error handling works.
    /// </summary>
    public class ErrorHandler : IRequestHandler<ErrorQuery, int>
    {
        public Task<int> Handle(ErrorQuery request, CancellationToken cancellationToken)
        {
            throw new Exception("Testing Error throwing in the ErrorHandler");
        }
    }
}

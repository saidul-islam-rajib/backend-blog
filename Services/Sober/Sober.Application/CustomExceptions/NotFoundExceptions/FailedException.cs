using BuildingBlocks.Exceptions;

namespace Sober.Application.CustomExceptions.NotFoundExceptions;

public class FailedException : BadRequestException
{
    public FailedException(string message) : base(message)
    {
    }
}

using BuildingBlocks.Exceptions;

namespace Sober.Application.CustomExceptions.NotFoundExceptions;

public class TagFailedException : BadRequestException
{
    public TagFailedException(string message) : base(message)
    {
    }
}

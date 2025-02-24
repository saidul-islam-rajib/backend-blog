using BuildingBlocks.Exceptions;

namespace Sober.Application.CustomExceptions.NotFoundExceptions;

public class ExperienceNotFoundException : NotFoundException
{
    public ExperienceNotFoundException(Guid Id) : base("Experience", Id)
    {        
    }
}

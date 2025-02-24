using BuildingBlocks.Exceptions;

namespace Sober.Api.ErrorHandling.NotFoundExceptions;

public class TagNotFoundException : NotFoundException
{
    public TagNotFoundException(Guid Id) : base("Tag", Id)
    {
        
    }
}

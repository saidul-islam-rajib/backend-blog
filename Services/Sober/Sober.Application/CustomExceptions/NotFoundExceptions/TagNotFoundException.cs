using BuildingBlocks.Exceptions;

namespace Sober.Application.CustomeExceptions.NotFoundExceptions;

public class TagNotFoundException : NotFoundException
{
    public TagNotFoundException(Guid Id) : base("Tag", Id)
    {        
    }
}

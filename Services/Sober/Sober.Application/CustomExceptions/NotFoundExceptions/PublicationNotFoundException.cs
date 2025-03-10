using BuildingBlocks.Exceptions;

namespace Sober.Application.CustomExceptions.NotFoundExceptions;

public class PublicationNotFoundException : NotFoundException
{
    public PublicationNotFoundException(Guid Id) : base("Publication", Id)
    {        
    }
}

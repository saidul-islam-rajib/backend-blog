using BuildingBlocks.Exceptions;

namespace Sober.Application.CustomExceptions.NotFoundExceptions;

public class InterestNotFoundException : NotFoundException
{
    public InterestNotFoundException(Guid Id) : base("Interest", Id)
    {
        
    }
}

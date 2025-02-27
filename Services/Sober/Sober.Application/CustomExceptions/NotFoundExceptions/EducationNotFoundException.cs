using BuildingBlocks.Exceptions;

namespace Sober.Application.CustomExceptions.NotFoundExceptions;

class EducationNotFoundException : NotFoundException
{
    public EducationNotFoundException(Guid Id) : base("Education", Id)
    {        
    }
}

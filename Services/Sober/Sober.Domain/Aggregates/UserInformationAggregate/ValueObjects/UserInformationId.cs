using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.UserInformationAggregate.ValueObjects;

public sealed class UserInformationId : ValueObject
{
    public Guid Value { get; private set; }
    public UserInformationId(Guid value)
    {
        Value = value;
    }

    public static UserInformationId CreateUnique()
    {
        return new UserInformationId(Guid.NewGuid());
    }

    public static UserInformationId Create(Guid value)
    {
        return new UserInformationId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

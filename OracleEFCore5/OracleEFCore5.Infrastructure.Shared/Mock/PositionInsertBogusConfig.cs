using Bogus;
using OracleEFCore5.Domain.Entities;


namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class PositionInsertBogusConfig : Faker<Position>
    {
        public PositionInsertBogusConfig()
        {
            RuleFor(o => o.PositionTitle, f => f.Name.JobTitle());
            RuleFor(o => o.PositionNumber, f => f.Commerce.Ean13());
            RuleFor(o => o.PositionDescription, f => f.Name.JobDescriptor());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
            RuleFor(o => o.PositionSalary, f => f.Finance.Amount());
        }
    }
}

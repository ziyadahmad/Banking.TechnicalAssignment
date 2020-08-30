using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Banking.TechnicalAssignment.Api.Persistance.Repositories
{
    public class LiteDbContext : ILiteDbContext
    {
        public ILiteDatabase Database { get; }

        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
            Database.DropCollection(nameof(Account));
            Database.DropCollection(nameof(Customer));
            Database.DropCollection(nameof(AccountTransaction));
        }
    }
}

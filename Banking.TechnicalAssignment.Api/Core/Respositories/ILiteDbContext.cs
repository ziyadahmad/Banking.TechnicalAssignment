using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace Banking.TechnicalAssignment.Api.Core.Respositories
{
    public interface ILiteDbContext
    {
        ILiteDatabase Database { get; }
    }
}

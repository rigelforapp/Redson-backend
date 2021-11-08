using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.Models;

namespace Redson_backend.DataAccess
{
    public interface IDataAccessProvider
    {
        List<Accounts> GetAccountsRecords();
        Accounts GetAccountsSingleRecord(int id);
        void AddAccountsRecord(Accounts accounts);
        void UpdateAccountRecord(Accounts accounts);
        void DeleteAccountRecord(int id);

    }
}

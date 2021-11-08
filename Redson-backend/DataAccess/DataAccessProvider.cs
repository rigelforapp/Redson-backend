using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.Models;

namespace Redson_backend.DataAccess
{
    public class DataAccessProvider: IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public List<Accounts> GetAccountsRecords()
        {

            return _context.accounts.ToList();
        }

        public Accounts GetAccountsSingleRecord(int id)
        {
            return _context.accounts.FirstOrDefault(t => t.id== id);
        }

        public void AddAccountsRecord(Accounts accounts)
        {
            _context.accounts.Add(accounts);
            _context.SaveChanges();
        }

        public void UpdateAccountRecord(Accounts accounts)
        {
            _context.accounts.Update(accounts);
            _context.SaveChanges();
        }
        public void DeleteAccountRecord(int id)
        {
            var entity = _context.accounts.FirstOrDefault(t => t.id == id);
            _context.accounts.Remove(entity);
            _context.SaveChanges();
        }

    }
}

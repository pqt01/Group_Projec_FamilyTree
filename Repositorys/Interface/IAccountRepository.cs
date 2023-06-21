using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositorys.Interface
{
    public interface IAccountRepository
    {
        Account GetByEmail(string email);
        Account GetAccountById(int id);
        List<Account> GetListAccountByName(string name);
        void Add(Account account);
        List<Account> GetAll();
        int Update(Account account);
        void Delete(int accId);
        Account CheckLogin(string email, string password);
    }
}

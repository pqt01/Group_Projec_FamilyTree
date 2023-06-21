using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System.Collections.Generic;

namespace Repositorys
{
    public class AccountRepository : IAccountRepository
    {
        private AccountDAO _dao;
        public AccountRepository()
        {
            _dao = new AccountDAO();
        }

        public List<Account> GetAll() => _dao.GetAll();
        public Account GetAccountById(int id) => _dao.GetAccountById(id);
        public void Add(Account account) => _dao.Add(account);
        public int Update(Account account) => _dao.Update(account);
        public void Delete(int accID) => _dao.Delete(accID);
        public Account GetByEmail(string email) => _dao.GetAccountByEmail(email);
        public List<Account> GetListAccountByName(string name) => _dao.GetListAccountByName(name);
        public Account CheckLogin(string email, string password) => _dao.checkLogin(email, password);
    }
}

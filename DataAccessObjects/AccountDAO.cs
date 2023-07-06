using BusinessObjects.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    //public class AccountDAO
    //{
    //    private FUFamilyTreeContext _dbContext;
    //    public AccountDAO()
    //    {
    //        _dbContext = new FUFamilyTreeContext();
    //    }
    //    public Account GetAccountByEmail(string email)
    //    {
    //        return _dbContext.Accounts.FirstOrDefault(c => c.Email == email);
    //    }

    //    public Account GetAccountById(int Id)
    //    {
    //        return _dbContext.Accounts.FirstOrDefault(c => c.Id == Id);
    //    }
    //    public List<Account> GetListAccountByName(string name)
    //    {
    //        return _dbContext.Accounts.Where(c => c.Username.Equals(name)).ToList();
    //    }

    //    public void Add(Account account)
    //    {
    //        _dbContext.Add(account);
    //        _dbContext.SaveChanges();
    //    }

    //    public List<Account> GetAll()
    //    {
    //        return _dbContext.Accounts.ToList();
    //    }

    //    public int Update(Account account)
    //    {
    //        var acc = GetAccountById(account.Id);
    //        if (acc != null)
    //        {
    //            acc.Username = account.Username;
    //            acc.Password = account.Password;
    //            acc.Email = account.Email;
    //            acc.PhoneNumber = account.PhoneNumber;
    //            acc.Role = account.Role;

    //            return _dbContext.SaveChanges();
    //        }
    //        return 0;
    //    }

    //    public void Delete(int accID)
    //    {
    //        var flag = GetAccountById(accID);
    //        if (flag != null)
    //        {
    //            _dbContext.Accounts.Remove(flag);
    //            _dbContext.SaveChanges();
    //        }
    //    }
    //    public Account checkLogin(string email, string password)
    //    {
    //        return _dbContext.Accounts.FirstOrDefault(c => c.Email == email && c.Password == password);
    //    }
    //}
}

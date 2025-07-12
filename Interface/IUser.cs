using studentTamu.Models;

namespace studentTamu.Interface
{
    public interface IUser
    {
        AccountsModel Login(AccountsModel am);
        List<AccountsModel> UserList();
        int InsertUser(AccountsModel am);
        AccountsModel GetUserId(int userId);
        int UpdateUser(AccountsModel am);
        int DeleteUser(int id);
    }
}

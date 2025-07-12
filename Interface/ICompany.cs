using studentTamu.Models;

namespace studentTamu.Interface
{
    public interface ICompany
    {
        CompanyModel companyData();
        int InsertCompany(CompanyModel cm);
        int checkCompany();
        AccountsModel checkUser();
        int checkRole();
        int deleteRoleAll();
        List<RoleModel> GetAllRoleList();
        int InsertRole(RoleModel rm);
    }
}

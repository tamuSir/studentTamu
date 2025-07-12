using Dapper;
using studentTamu.Interface;
using studentTamu.Models;
using System.Data;

namespace studentTamu.Repository
{
    public class CompanyRepo : ICompany
    {
        private readonly IDbConnection db;

        public CompanyRepo(IDbConnection _db)
        {
            db = _db;
        }

        public int checkCompany()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "checkCompanyThereOrNot");

                var data = SqlMapper.Query<int>(db, "proc_company", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public int checkRole()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "checkRoleIsThereOrNot");

                var data = SqlMapper.Query<int>(db, "proc_company", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public AccountsModel checkUser()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "checkUserAdminThereOrNot");

                var data = SqlMapper.Query<AccountsModel>(db, "proc_company", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public CompanyModel companyData()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "getCompany");

                var data = SqlMapper.Query<CompanyModel>(db, "proc_company", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public int deleteRoleAll()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "deleteRoleAllData");

                var data = SqlMapper.Query<int>(db, "proc_company", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public List<RoleModel> GetAllRoleList()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "getALlRole");

                var data = SqlMapper.Query<RoleModel>(db, "proc_company", param, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public int InsertCompany(CompanyModel cm)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@companyName", cm.companyName);
                param.Add("@address", cm.address);
                param.Add("@phone", cm.phone);
                param.Add("@email", cm.email);
                param.Add("@flag", "AddCompany");

                var data = SqlMapper.Query<int>(db, "proc_company", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public int InsertRole(RoleModel rm)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@intRoleid", rm.intRoleId);
                param.Add("@roleName",rm.roleName);
                param.Add("@flag", "insertRole");

                var data = SqlMapper.Query<int>(db,"proUser",param,commandType:CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Close();
            }
        }
    }
}

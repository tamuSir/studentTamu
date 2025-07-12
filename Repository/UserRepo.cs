using Dapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using studentTamu.Interface;
using studentTamu.Models;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace studentTamu.Repository
{
    public class UserRepo : IUser
    {
        private readonly IDbConnection db;
        public UserRepo(IDbConnection _db)
        {
            db= _db;
        }

        public int DeleteUser(int id)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@intUserId",id);
                param.Add("@flag", "deleteUser");

                var data = SqlMapper.Query<int>(db, "proUser", param,commandType:CommandType.StoredProcedure).FirstOrDefault();
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

        public AccountsModel GetUserId(int userId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@intUserId", userId);
                param.Add("@flag", "getUserId");

                var data = SqlMapper.Query<AccountsModel>(db, "proUser", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public int InsertUser(AccountsModel am)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@name", am.name);
                param.Add("@username", am.username);
                param.Add("@email", am.email);
                param.Add("@fromDate", am.fromDate);
                param.Add("@toDate", am.toDate);
                param.Add("@intRoleid", am.intRoleid);
                param.Add("@password", am.password);
                param.Add("@flag", "InsertUser");

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

        public AccountsModel Login(AccountsModel am)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@username", am.username);
                param.Add("@password", am.password);
                param.Add("@flag", "userLogin");
                var data = SqlMapper.Query<AccountsModel>(db, "proUser", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public int UpdateUser(AccountsModel am)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@name", am.name);
                param.Add("@email", am.email);
                param.Add("@status", am.status);
                param.Add("@intUserId", am.intUserId);
                param.Add("@flag", "updateUser");

                var data = SqlMapper.Query<int>(db, "proUser", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public List<AccountsModel> UserList()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "userList");
                var data=SqlMapper.Query<AccountsModel>(db,"proUser",param,commandType: CommandType.StoredProcedure).ToList();
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

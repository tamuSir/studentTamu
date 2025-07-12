using Dapper;
using studentTamu.Interface;
using studentTamu.Models;
using System.Data;
using System.Security.Cryptography;

namespace studentTamu.Repository
{
    public class StudentRepo : IStudent
    {
        private readonly IDbConnection db;

        public StudentRepo(IDbConnection _db)
        {
            db = _db;
        }

        public int DeleteStudent(int studentId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", studentId);
                param.Add("@flag", "deleteStudentAllData");

                var data = SqlMapper.Query<int>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public StudentFormModel getevidenceOfEnglish(int personalDId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", personalDId);
                param.Add("@flag", "getevidenceOfEnglishId");
                var data = SqlMapper.Query<StudentFormModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public StudentFormModel getstudentEducation(int personalDId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", personalDId);
                param.Add("@flag", "getstudentEducationId");
                var data = SqlMapper.Query<StudentFormModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public StudentFormModel getstudentExperienceLetter(int personalDId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", personalDId);
                param.Add("@flag", "getstudentExperienceLetterId");
                var data = SqlMapper.Query<StudentFormModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public StudentFormModel getstudentPersonalDetail(int personalDId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@sPId", personalDId);
                param.Add("@flag", "getStudentId");
                var data = SqlMapper.Query<StudentFormModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public List<StudentFormModel> studentEducationList(int personalDId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", personalDId);
                param.Add("@flag", "getstudentEducationId");
                var data = SqlMapper.Query<StudentFormModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).ToList();
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

        public List<StudentFormModel> studentExperienceLetterList(int personalDId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", personalDId);
                param.Add("@flag", "getstudentExperienceLetterId");
                var data = SqlMapper.Query<StudentFormModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).ToList();
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

        public List<StudentFormModel> StudentPersonalDetailList()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "getStudentPersonalDetailList");
                var data = SqlMapper.Query<StudentFormModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).ToList();
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
        public List<StudentFormModel> evidenceOfEnglishList(int personalDId)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", personalDId);
                param.Add("@flag", "getevidenceOfEnglishId");
                var data = SqlMapper.Query<StudentFormModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).ToList();
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

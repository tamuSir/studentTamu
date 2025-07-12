using Dapper;
using studentTamu.Interface;
using studentTamu.Models;
using System.Data;

namespace studentTamu.Repository
{
    public class StudentFormRepo : IStudentForm
    {
        private readonly IDbConnection db;

        public StudentFormRepo(IDbConnection _db)
        {
            db = _db;
        }      
        
        public int InsertStudentFormEducation(StudentFormModel sfm)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", sfm.pdID);
                param.Add("@degreeName", sfm.degreeName);
                param.Add("@institutionName", sfm.institutionName);
                param.Add("@academicGrading", sfm.academicGrading);
                param.Add("@marks", sfm.marks);
                param.Add("@dateOfCompletion", sfm.dateOfCompletion);
                //param.Add("@isActive", sfm.isActive);
                param.Add("@flag", "AddStudentEducation");

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

        public int InsertStudentFormEnglishEvidence(StudentFormModel sfm)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", sfm.pdID);
                param.Add("@englishTest", sfm.englishTest);
                param.Add("@testName", sfm.testName);
                param.Add("@speaking", sfm.speaking);
                param.Add("@listening", sfm.listening);
                param.Add("@reading", sfm.reading);
                param.Add("@writing", sfm.writing);
                param.Add("@overall", sfm.overall);
                param.Add("@dateOfTest", sfm.dateOfTest);
                //param.Add("@isActive", sfm.isActive);
                param.Add("@flag", "AddEvidenceEnglish");

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

        public int InsertStudentFormExperience(StudentFormModel sfm)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@pdID", sfm.pdID);
                param.Add("@orgName", sfm.orgName);
                param.Add("@position", sfm.position);
                param.Add("@fromDate", sfm.fromDate);
                param.Add("@toDate", sfm.toDate);
                //param.Add("@isActive", sfm.isActive);
                param.Add("@flag", "AddExperienceLetter");

                var dataa = SqlMapper.Query<int>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return dataa;
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

        public ResponseDetailsModel InsertStudentFormPersonalDetail(StudentFormModel sfm)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@firstName", sfm.firstName);
                param.Add("@lastName", sfm.lastName);
                param.Add("@dateOfBirth", sfm.dateOfBirth);
                param.Add("@gender", sfm.gender);
                param.Add("@email", sfm.email);
                param.Add("@telephone", sfm.telephone);
                param.Add("@phone", sfm.phone);
                param.Add("@address", sfm.address);
                param.Add("@martialStatus", sfm.martialStatus);
                //param.Add("@isActive", sfm.isActive);
                param.Add("@flag", "AddPersonalDetail");

                var data = SqlMapper.Query<ResponseDetailsModel>(db, "procStudentForm", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

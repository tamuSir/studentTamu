using Dapper;
using studentTamu.Interface;
using studentTamu.Models;
using System.Data;

namespace studentTamu.Repository
{
    public class DocumentRepo:IDocument
    {
        private readonly IDbConnection db;

        public DocumentRepo(IDbConnection _db)
        {
            db = _db;
        }

        public int DeleteDocument(int id)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@documentId", id);
                param.Add("@flag", "deleteDocumentData");

                var data = SqlMapper.Query<int>(db, "proc_document", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public List<DocumentModel> GetAllDocuments()
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "GetDocumentListData");

                var data = SqlMapper.Query<DocumentModel>(db, "proc_document", param, commandType: CommandType.StoredProcedure).ToList();
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

        public DocumentModel getDocumentById(int id)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@documentId", id);
                param.Add("@flag", "GetDocumentById");

                var data = SqlMapper.Query<DocumentModel>(db, "proc_document", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public int InsertDocument(DocumentModel dm)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@userId", dm.userId);
                param.Add("@dImage", dm.dImage);
                param.Add("@flag", "InsertDocument");

                var data = SqlMapper.Query<int>(db, "proc_document", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public int UpdateDocument(DocumentModel dm)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@documentId", dm.documentId);
                param.Add("@userId", dm.userId);
                param.Add("@dImage", dm.dImage);
                //param.Add("@status", dm.status);
                param.Add("@flag", "UpdateDocument");

                var data = SqlMapper.Query<int>(db, "proc_document", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

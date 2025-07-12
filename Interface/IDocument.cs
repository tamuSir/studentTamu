using studentTamu.Models;

namespace studentTamu.Interface
{
    public interface IDocument
    {
        int InsertDocument(DocumentModel dm);
        int UpdateDocument(DocumentModel dm);
        DocumentModel getDocumentById(int id);
        List<DocumentModel> GetAllDocuments();
        int DeleteDocument(int id);
    }
}

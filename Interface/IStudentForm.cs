using studentTamu.Models;

namespace studentTamu.Interface
{
    public interface IStudentForm
    {
        ResponseDetailsModel InsertStudentFormPersonalDetail(StudentFormModel sfm);
        int InsertStudentFormEducation(StudentFormModel sfm);
        int InsertStudentFormExperience(StudentFormModel sfm);
        int InsertStudentFormEnglishEvidence(StudentFormModel sfm);
    }
}

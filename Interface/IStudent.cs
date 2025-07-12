using studentTamu.Models;

namespace studentTamu.Interface
{
    public interface IStudent
    {
        //StudentModel getStudentId(int sId);
        //List<StudentModel> StudentList();
        //int DeleteStudent(int studentId,int intRoleid);

        StudentFormModel getstudentPersonalDetail(int personalDId);
        StudentFormModel getevidenceOfEnglish(int personalDId);
        StudentFormModel getstudentEducation(int personalDId);
        StudentFormModel getstudentExperienceLetter(int personalDId);
        List<StudentFormModel> StudentPersonalDetailList();
        List<StudentFormModel> evidenceOfEnglishList(int personalDId);
        List<StudentFormModel> studentEducationList(int personalDId);
        List<StudentFormModel> studentExperienceLetterList(int personalDId);
        int DeleteStudent(int studentId);

    }
}

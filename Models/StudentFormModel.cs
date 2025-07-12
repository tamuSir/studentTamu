namespace studentTamu.Models
{
    public class StudentFormModel
    {
        //common
        public int pdID { get; set; }
        public bool isActive { get; set; }

        //personal detail
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string martialStatus { get; set; }

        //education
        public int eId { get; set; }
        public string degreeName { get; set; }
        public string institutionName { get; set; }
        public string academicGrading { get; set; }
        public string marks { get; set; }
        public string dateOfCompletion { get; set; }
        public List<StudentFormModel> eduArrData { get; set; }

        // experience
        public int exID { get; set; }
        public string orgName { get; set; }
        public string position { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public List<StudentFormModel> expArrData { get; set; }

        //evidence of english
        public int enID { get; set; }
        public string englishTest { get; set; }
        public string testName { get; set; }
        public string speaking { get; set; }
        public string listening { get; set; }
        public string reading { get; set; }
        public string writing { get; set; }
        public string overall { get; set; }
        public string dateOfTest { get; set; }

    }
}

namespace DataAccessLayer
{
    public partial class Course
    {
        public override string ToString()
        {
            return "CourseID : " + CourseID + " " + "Credirs Required: " + Credits;
        }
    }
}
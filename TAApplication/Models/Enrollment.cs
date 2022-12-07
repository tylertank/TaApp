namespace TAApplication.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public Course course { get; set; }
        public DateTime enrolledTime { get; set; }
        public int enrollment { get; set; }

    }
}

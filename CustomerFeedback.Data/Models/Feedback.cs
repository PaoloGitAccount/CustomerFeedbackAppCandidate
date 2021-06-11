using System.ComponentModel.DataAnnotations;

namespace CustomerFeedback.Data
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Comment { get; set; }
    }
}

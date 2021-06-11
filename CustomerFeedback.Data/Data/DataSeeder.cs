using System.Collections.Generic;
using System.Linq;

namespace CustomerFeedback.Data.Data
{
    public class DataSeeder
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Feedback.Any())
            {
                var feedbacks = new List<Feedback>()
                {
                    new Feedback { /*Id = 1,*/ FirstName = "John", Lastname = "surname1", Comment = "commentLineline" },
                    new Feedback { /*Id = 2,*/ FirstName = "Peter", Lastname = "surname2", Comment = "commentLineline2" }
                };
                context.Feedback.AddRange(feedbacks);
                context.SaveChanges();
            }  
        }
    }
}

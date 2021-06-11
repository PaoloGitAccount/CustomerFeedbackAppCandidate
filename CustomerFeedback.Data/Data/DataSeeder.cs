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
                    //new User { /*Id = 1,*/ Name = "John", Email = "john@john.com" },
                    //new User { /*Id = 2,*/ Name = "Michael", Email = "michael@michael.com" }
                    new Feedback { /*Id = 1,*/ FirstName = "John", Lastname = "surname1", Comment = "commentLineline" },
                    new Feedback { /*Id = 2,*/ FirstName = "Peter", Lastname = "surname2", Comment = "commentLineline2" }
                };
                context.Feedback.AddRange(feedbacks);
                context.SaveChanges();
            }

            //if (!context.Recipes.Any())
            //{
            //    var recipes = new List<Recipe>()
            //{
            //    new Recipe { /* Id = 1 */ Name = "Pizza", Description = "A random description from a pizza", Difficulty = RecipeDifficulty.MEDIUM, ImagePath = "https://upload.wikimedia.org/wikipedia/commons/a/a4/Pizza.jpg", Time = 30, UserId = 1 }
            //};
            //    context.Recipes.AddRange(recipes);
            //    context.SaveChanges();
            //}

            //if (!context.Ingredients.Any())
            //{
            //    var ingredients = new List<Ingredient>()
            //{
            //    new Ingredient { /* Id = 1 */ Name = "Cheese", Amount = 1, RecipeId = 1 },
            //    new Ingredient { /* Id = 2 */ Name = "Tomato", Amount = 2, RecipeId = 1 }
            //};
            //    context.Ingredients.AddRange(ingredients);
            //    context.SaveChanges();
            //}
        }
    }
//}
}

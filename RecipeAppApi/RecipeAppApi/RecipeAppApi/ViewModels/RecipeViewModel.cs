using RecipeAppApi.Models;

namespace RecipeAppApi.ViewModels
{
    public class RecipeViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }   

        public string Summary { get; set; } 

        public RecipeViewModel (Recipe recipe)
        {
            Id = recipe.Id.ToString();
            Title = recipe.Title; 
            Summary = recipe.Summary;
        }
    }
}

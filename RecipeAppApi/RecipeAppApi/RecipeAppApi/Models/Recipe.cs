using MongoDB.Bson;

namespace RecipeAppApi.Models
{
    public class Recipe
    {
        public ObjectId Id { get; set; }    
        public string Image { get; set; }
        
        public string Title { get; set; }  
        
        public string Summary { get; set; }
        
        public int Minutes { get; set; }    
    }
}

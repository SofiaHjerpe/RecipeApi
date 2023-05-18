using MongoDB.Bson;
using MongoDB.Driver;
using RecipeAppApi.Models;

namespace RecipeAppApi
{
    public class Database
    {
        private IMongoDatabase GetDb()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MyRecipeDB");
            return db;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            var recipes = await GetDb().GetCollection<Recipe>("Recipes")
                .Find(r => true) .ToListAsync();    
            return recipes; 

        }

        public async Task<Recipe> GetRecipe(string id)
        {
            ObjectId _id = new ObjectId(id);
            var recipe = await GetDb().GetCollection<Recipe>("Recipes")
                .Find(r => r.Id == _id)
                .SingleOrDefaultAsync();
            return recipe;
        }
        public async Task SaveRecipe(string title, string summary, int minutes)
        {
            var recipe = new Recipe()
            {
                Title = title,
                Summary = summary,
                Minutes = minutes
            };
           


            await GetDb().GetCollection<Recipe>("Recipes")
                .InsertOneAsync(recipe);
        }

        public async Task DeleteRecipe(string id)
        {
            ObjectId _id = new ObjectId(id);
            await GetDb().GetCollection<Recipe>("Recipes")
                .DeleteOneAsync(r => r.Id == _id);
        }
        public async Task UpdateRecipe(string id, string title, string summary)
        {
            ObjectId _id = new ObjectId(id);
          
            var update = Builders<Recipe>.Update
               .Set(r => r.Title, title);
            var update1 = Builders<Recipe>.Update
            .Set(r => r.Summary, summary);


            await GetDb().GetCollection<Recipe>("Recipes")
              .UpdateOneAsync(r => r.Id == _id, update);
            await GetDb().GetCollection<Recipe>("Recipes")
             .UpdateOneAsync(r => r.Id == _id, update1);
        }
    }
}

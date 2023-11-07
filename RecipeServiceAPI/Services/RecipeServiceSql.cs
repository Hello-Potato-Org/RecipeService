using Npgsql;
using Dapper;
using RecipeServiceAPI.Controllers;
using RecipeServiceAPI.Models;



namespace RecipeServiceAPI.Services
{
    public class RecipeServiceSql : IRecipeService
    {
        private readonly string? _dbConnection = Environment.GetEnvironmentVariable("connectionstring");
        private readonly ILogger<RecipeController> _logger;

        public RecipeServiceSql(ILogger<RecipeController> logger)
        {
            _logger = logger;
        }

        //Post Recipe
        public async Task<int> CreateRecipe(RecipeDTO RecipeDTO)
        {
            string sql = $"INSERT INTO public.recipes (name, servingsize, imageid) VALUES ('{RecipeDTO.Name}', {RecipeDTO.ServingSize}, {RecipeDTO.ImageId}) RETURNING id";

            await using var connection = new NpgsqlConnection(_dbConnection);
            try
            {
                return connection.Execute(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the Recipe to the database: " + e.Message);
                throw new InvalidDataException();
            }

        }

        public async Task<RecipeDTO> ReadRecipe(int recipeId)
        {
            Console.WriteLine("Get RecipeDTO by ID");
            string sql = $"SELECT * FROM public.recipes WHERE id = {recipeId}";

            await using var connection = new NpgsqlConnection(_dbConnection);
            try
            {
                return connection.Query<RecipeDTO>(sql).First();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't find the Recipe in database: " + e.Message);
                throw new InvalidDataException();
            }
        }

        public async Task<RecipeDTO> UpdateRecipe(RecipeDTO RecipeDTO)
        {
            string sql = $"UPDATE public.recipes SET name = '{RecipeDTO.Name}', servingsize = {RecipeDTO.ServingSize}, imageid = {RecipeDTO.ImageId} WHERE id = {RecipeDTO.Id}";

            await using var connection = new NpgsqlConnection(_dbConnection);
            try
            {
                connection.Query<RecipeDTO>(sql);
                return RecipeDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't update the Recipe in the database: " + e.Message);
                throw new InvalidDataException();
            }


        }
        public async Task<bool> DeleteRecipe(int RecipeId)
        {
            string sql = $"DELETE FROM public.recipes WHERE id = {RecipeId}";

            await using var connection = new NpgsqlConnection(_dbConnection);
            try
            {
                connection.Execute(sql);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't update the Recipe in the database: " + e.Message);
                throw new InvalidDataException();
            }
        }
    }
}

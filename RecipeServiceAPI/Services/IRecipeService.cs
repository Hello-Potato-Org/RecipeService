using System;
using RecipeServiceAPI.Models;

namespace RecipeServiceAPI.Services
{
    public interface IRecipeService
    {
        Task <int> CreateRecipe(RecipeDTO RecipeDTO);
        Task<RecipeDTO> ReadRecipe(int RecipeId);
        Task<RecipeDTO> UpdateRecipe(RecipeDTO RecipeDTO);
        Task<bool> DeleteRecipe(int RecipeId);
    }
}
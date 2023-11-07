using Microsoft.AspNetCore.Mvc;
using RecipeServiceAPI.Models;
using RecipeServiceAPI.Services;

namespace RecipeServiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{

    private readonly ILogger<RecipeController> _logger;
    private readonly IRecipeService _recipeService;

    public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<RecipeDTO?> GetData(int id) => await _recipeService.ReadRecipe(id);

    [HttpPost]
    public async Task<int?> PostData(string name, int servingSize, int imageId) => await _recipeService.CreateRecipe(new RecipeDTO(name, servingSize, imageId));

    [HttpPut]
    public async Task<RecipeDTO?> PutData(int id, string name, int servingSize, int imageId) => await _recipeService.UpdateRecipe(new RecipeDTO(id, name, servingSize, imageId));

    [HttpDelete]
    public async Task<bool?> DeleteData(int recipeId) => await _recipeService.DeleteRecipe(recipeId);


}

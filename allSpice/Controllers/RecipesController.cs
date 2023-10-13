
namespace allSpice.Controllers;

[ApiController]
[Route("api/recipes")]

public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0;


    public RecipesController(RecipesService recipesService, IngredientsService ingredientsService, Auth0Provider auth0)
    {
        _recipesService = recipesService;
        _ingredientsService = ingredientsService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe newRecipe = _recipesService.Create(recipeData);
            return newRecipe;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> Get()
    {
        try
        {
            List<Recipe> recipes = _recipesService.Get();
            return recipes;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipesService.Get(recipeId);
            return recipe;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpPut("{recipeId}")]
    public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe updateData, int recipeId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            updateData.CreatorId = userInfo.Id;
            updateData.Id = recipeId;
            Recipe updatedRecipe = _recipesService.UpdateRecipe(updateData);
            return Ok(updatedRecipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{recipeId}")]
    public async Task<ActionResult<string>> RemoveRecipe(int recipeId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            string message = _recipesService.RemoveRecipe(recipeId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipe(int recipeId)
    {
        try
        {
            List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipe(recipeId);
            return ingredients;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
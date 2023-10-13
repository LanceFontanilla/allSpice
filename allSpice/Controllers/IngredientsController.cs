
using System.ComponentModel;

namespace allSpice.Controllers;

[ApiController]
[Route("api/ingredients")]

public class IngredientsController : ControllerBase
{

    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0;

    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0)
    {
        _ingredientsService = ingredientsService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]

    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);

            Ingredient newIngredient = _ingredientsService.CreateIngredient(ingredientData, userInfo);
            return newIngredient;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [Authorize]
    [HttpDelete("{ingredientId}")]
    public ActionResult<string> DeleteIngredient(int ingredientId)
    {
        try
        {
            _ingredientsService.DeleteIngredient(ingredientId);
            return "This ingredient has been deleted";
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

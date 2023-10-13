
namespace allSpice.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavoritesController : ControllerBase
{

    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0;
    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0)
    {
        _favoritesService = favoritesService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favorData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            favorData.AccountId = userInfo.Id;
            Favorite newFavor = _favoritesService.CreateFavorite(favorData);
            return newFavor;

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{favoriteId}")]
    public async Task<ActionResult<string>> DeleteFavorite(int favorId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            _favoritesService.DeleteFavorite(favorId);

            return "Successfully removed favorite.";
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
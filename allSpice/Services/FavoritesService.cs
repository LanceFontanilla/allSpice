

using Microsoft.AspNetCore.Builder;

namespace allSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
        _repo = repo;
    }

    internal Favorite CreateFavorite(Favorite favorData)
    {
        Favorite newFavor = _repo.CreateFavorite(favorData);
        return newFavor;
    }

    internal void DeleteFavorite(int favoriteId)
    {
        _repo.DeleteFavorite(favoriteId);
    }

    internal List<FavoriteRecipeViewModel> GetRecipesByAccount(string accountId)
    {
        List<FavoriteRecipeViewModel> myRecipes = _repo.GetRecipesByAccount(accountId);
        return myRecipes;
    }
}
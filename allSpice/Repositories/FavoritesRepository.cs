



namespace allSpice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favorData)
    {
        string sql = @"
        INSERT INTO favorites
        (recipeId, accountId)
        VALUES
        (@recipeId, @accountId);    
        SELECT LAST_INSERT_ID()
        ;";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favorData);
        favorData.Id = lastInsertId;
        return favorData;
    }

    internal void DeleteFavorite(int favorId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favorId
        LIMIT 1
        ;";
        _db.Execute(sql, new { favorId });
    }

    internal Favorite GetById(int favorId)
    {
        string sql = @"
        SELECT
        *
        From favorites
        WHERE id = @favorId
        ;";
        Favorite favor = _db.Query<Favorite>(sql, new { favorId }).FirstOrDefault();
        return favor;
    }

    internal List<FavoriteRecipeViewModel> GetRecipesByAccount(string accountId)
    {
        string sql = @"
        SELECT 
        favor.*,
        rec.*
        FROM favorites favor
        JOIN recipes rec ON rec.id = favor.recipeId
        WHERE favor.accountId = @accountId
        ;";
        List<FavoriteRecipeViewModel> myRecipes = _db.Query<Favorite, FavoriteRecipeViewModel, FavoriteRecipeViewModel>(sql, (favor, recipe) =>
        {
            recipe.FavoriteId = favor.Id;
            recipe.AccountId = favor.AccountId;
            return recipe;
        }, new { accountId }).ToList();
        return myRecipes;
    }
}
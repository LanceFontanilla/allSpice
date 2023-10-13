

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
        favorData.Id = lastInsertId.ToString();
        return favorData;
    }
}
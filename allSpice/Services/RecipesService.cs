

namespace allSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

    internal Recipe Create(Recipe recipeData)
    {
        Recipe newRecipe = _repo.Create(recipeData);
        return newRecipe;
    }

    internal List<Recipe> Get()
    {
        List<Recipe> recipes = _repo.Get();
        return recipes;
    }

    internal Recipe Get(int recipeId)
    {
        Recipe foundRecipe = _repo.Get(recipeId);
        if (foundRecipe == null) throw new Exception($"Unable to find recipe at {recipeId}");
        return foundRecipe;
    }

    internal string RemoveRecipe(int recipeId, string userId)
    {
        Recipe recipe = this.Get(recipeId);
        if (recipe.CreatorId != userId) throw new Exception("Unauthorized");
        _repo.RemoveRecipe(recipeId);
        return $"This recipe {recipe.Title} has been removed from the database.";
    }

    internal Recipe UpdateRecipe(Recipe updateData)
    {
        Recipe original = this.Get(updateData.Id);
        //if (original.CreatorId != userId) throw new Exception("Unauthorized");

        original.Title = updateData.Title != null ? updateData.Title : original.Title;
        original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
        original.Img = updateData.Img != null ? updateData.Img : original.Img;
        original.Category = updateData.Category != null ? updateData.Category : original.Category;
        original.CreatorId = updateData.CreatorId != null ? updateData.CreatorId : original.CreatorId;
        original.Creator = updateData.Creator != null ? updateData.Creator : original.Creator;

        Recipe recipe = _repo.UpdateRecipe(original);
        return recipe;
    }
}
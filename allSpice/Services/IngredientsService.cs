


namespace allSpice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repo;


    public IngredientsService(IngredientsRepository repo)
    {
        _repo = repo;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, Account userInfo)
    {
        Ingredient newIngredient = _repo.CreateIngredient(ingredientData);
        return newIngredient;
    }

    internal void DeleteIngredient(int ingredientId)
    {
        _repo.DeleteIngredient(ingredientId);
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repo.GetIngredientsByRecipe(recipeId);
        return ingredients;
    }
}

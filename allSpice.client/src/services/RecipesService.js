import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService{

    async createRecipe(recipeData){
        const res = await api.post('api/recipes', recipeData)
        logger.log('created recipe', res.data)
        const newRecipe = new Recipe(res.data)
        AppState.recipes.unshift(newRecipe)
        return newRecipe
    }

    async getRecipes(){
        AppState.recipes = []
        const res = await api.get('api/recipes')
        logger.log('getting recipes', res.data)
        AppState.recipes = res.data.map(recipe => new Recipe(recipe))
    }

    async getIngredientsByRecipe(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('getting ingredients', recipeId)
        AppState.activeRecipeIngredients = res.data.map(ingredient => new Ingredient(ingredient))
        logger.log('this is the Ingredient', res.data)
    }

    async deleteRecipe(activeRecipeId){
        const res = await api.delete(`api/recipes/${activeRecipeId}`)
        logger.log('removed recipe', res.data)
        let indexToRemove = AppState.recipes.findIndex(recipe => recipe.id == activeRecipeId)
        AppState.recipes.splice(indexToRemove, 1)
    }

    searchRecipes(searchTerm){
        logger.log('this is the search term', searchTerm)
        AppState.filterRecipes = AppState.recipes.filter(recipe => recipe.category == searchTerm.search)
        logger.log(AppState.filterRecipes, 'this is the recipes after filter')
        AppState.recipes = AppState.filterRecipes
    }
    async clearSearch() {
        AppState.searchTerm = ''
        await recipesService.getRecipes()
    }
    
}



export const recipesService = new RecipesService()
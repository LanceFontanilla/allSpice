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

}

export const recipesService = new RecipesService()
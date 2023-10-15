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

    async getActiveRecipe(recipeId){
        const res = await api.get(`api/recipes/${recipeId}`)
        logger.log('getting active recipe', res.data)
        
        AppState.activeRecipe = new Recipe(res.data)
    }

    async getIngredientsByRecipe(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('getting ingredients', res.data)
        AppState.activeRecipeIngredients = res.data.map(ingredient => new Ingredient(ingredient))
    }

}

export const recipesService = new RecipesService()
import { AppState } from "../AppState"
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
}

export const recipesService = new RecipesService()
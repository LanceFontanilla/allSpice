import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"



class IngredientsService{
    async createIngredient(ingredientData){
        ingredientData.recipeId = AppState.activeRecipe.id
        const res = await api.post('api/ingredients', ingredientData)
        logger.log('created ingredient', res.data)
        const newIngredient = new Ingredient(res.data)
        AppState.activeRecipeIngredients.push(newIngredient)
    }




}


export const ingredientsService = new IngredientsService()
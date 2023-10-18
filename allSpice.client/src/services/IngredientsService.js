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

    async deleteIngredient(ingredientId){
        const res = await api.delete(`api/ingredients/${ingredientId}`)
        logger.log('removed Ingredient', res.data)
        let indexToRemove = AppState.activeRecipeIngredients.findIndex(ingredient => ingredient.id == ingredientId)
        AppState.activeRecipeIngredients.splice(indexToRemove, 1)
        logger.log('this is the id removed', indexToRemove)
        }
    

}






export const ingredientsService = new IngredientsService()
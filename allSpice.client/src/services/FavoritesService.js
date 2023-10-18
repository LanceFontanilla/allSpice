import { AppState } from "../AppState"
import { Favorite } from "../models/Favorite"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class FavoritesService{
    async createFavorite(recipeId){
        logger.log('this is the recipeId', recipeId)
        await api.post('api/favorites', recipeId)
        logger.log('created Favorite')
            
        this.getFavorites()
    
        logger.log('these are the favorites list', AppState.favorites)
    }
    
    async deleteFavorite(recipeId){
        logger.log('this is teh delete RECIPEID', recipeId)
        logger.log('these are the favorites in the delete', AppState.favorites)
        const favorite = AppState.favorites.find(favorite => favorite.id == recipeId)
        logger.log('this is teh favoriteId', favorite)
        await api.delete(`api/favorites/${favorite.favoriteId}`)
        logger.log('removing favorite from this recipe', recipeId)
        const foundFavorite = AppState.activeRecipe.find(recipe => recipe.favoriteId == favorite.favoriteId)
        if(foundFavorite) AppState.activeRecipe.splice(foundFavorite, 1)
        this.getFavorites()
}
    async getFavorites() {
        const res = await api.get('/account/favorites')
        AppState.favorites = res.data.map(favorite => new Favorite(favorite));
    }
}

export const favoritesService = new FavoritesService()
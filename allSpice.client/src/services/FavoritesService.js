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
    }
    async getFavorites() {
        const res = await api.get('/account/favorites')
        AppState.favorites = res.data.map(favorite => new Favorite(favorite));
    }
}

export const favoritesService = new FavoritesService()
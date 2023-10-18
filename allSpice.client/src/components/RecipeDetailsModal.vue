<template>
    <section v-if="activeRecipe" class="container">
        <div class="row">
            <div class="col-4">
                <img class="img-fluid rec-img" :src="activeRecipe.img" alt="">
            </div>
            
            <div class="col-8">
                <div class="row">
                    <div class="col-12 d-flex align-items-center p-4 pt-0">
                        <span class="title">{{ activeRecipe.title }}</span>
                    </div>            
                    <div class="col-6 d-flex align-items-center p-4 pt-0">
                        <span class="category px-3">{{ activeRecipe.category }}</span>
                    </div>
                    <div class="col-6 fs-3" >
                        <span role="button" @click="createFavorite(activeRecipeId)" class="mdi mdi-heart-multiple"></span>
                        <span class="mdi mdi-heart-multiple-outline"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">

                        <div class="direct-card card">
                            <div class="card-header bg-dark text-center">
                                <span class="header ">
                                    Instructions
                                </span>
                            </div>
                        <p class="card-body bg-secondary text-light mb-0 fs-4">{{ activeRecipe.instructions }}</p>
                        </div>
                    </div>
                    
                    <div class="col-6">
                        <IngredientCard/>                    
                    </div>

                </div>
            </div>
        </div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watchEffect } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { favoritesService } from '../services/FavoritesService'
import { logger } from '../utils/Logger';

import { Recipe } from '../models/Recipe';




export default {
    props: {
        recipeProp: {type: Recipe, required: true}
    },
    setup(props){

        const activeRecipe = computed(()=> AppState.activeRecipe)
        const activeRecipeIngredients = computed(() => AppState.activeRecipeIngredients)
        watchEffect(()=> {
            AppState.activeRecipe

            getIngredientsByRecipe()
        });
        async function getIngredientsByRecipe(){
            try {
                if(activeRecipe.value.id > 0)
                await recipesService.getIngredientsByRecipe(activeRecipe.value.id);
                logger.log('getting ingredients by recipeId', activeRecipe.value.id)
            } catch (error) {
                Pop.error(error)
            }
        }



        return { 
            account: computed(() => AppState.account), 
            activeRecipeId: computed(() => AppState.activeRecipe.id),            
            activeRecipe,
            activeRecipeIngredients,
            favorites: computed(() => AppState.favorites),
            isFavorite: computed(() => {
                let foundFavorite = AppState.favorites?.find(f => f.id == props.recipeProp.id)
                return foundFavorite;
            }),

            async createFavorite(activeRecipeId){
            try {
                let favoriteData = { recipeId: activeRecipeId }
                logger.log('this is the favorite recipe id', activeRecipeId)
                await favoritesService.createFavorite(favoriteData)
            } catch (error) {
                Pop.error(error)
            }
        }

        }
    },

};
</script>


<style lang="scss" scoped>
.rec-img{
    height: 100%;
    object-fit: cover;

}
.title{
    font-size: 3rem;
    font-weight: bold;
}
.category{
    background-color: rgba(17, 25, 39, 0.793);
    color: whitesmoke;
    border-radius: 5px;
    font-size: 1.5rem;
}


.bg-dark-grey{
    background-color: rgba(52, 58,64, 0.8);
}

.direct-card{
    height: 60vh;
    overflow-y: scroll;
    -ms-overflow-style: none;
    scrollbar-width: none; 
}
.direct-card::-webkit-scrollbar {
    display: none;
}
.header{
    font-size: 1.5rem;
}

</style>
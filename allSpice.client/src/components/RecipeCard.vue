<template>

        <div class="cover-img card bg-purple-light" data-bs-toggle="modal" data-bs-target="#exampleModal" @click="getActiveRecipe">
            <div class="p-0 m-2 mt-2">
            <p  class="fw-bold ">{{ recipe.title }}</p>
            </div>
            <div class="">
            <p class="p-0 m-2 ">{{ recipe.category }}</p>
            </div>
            <div class="">
            <p class="p-0 m-2 "><img class="img-fluid" :src="recipe.img" alt=""></p>
            </div>
        </div>

</template>



<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';

import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';

export default {
    props: {recipe: {type: Recipe, required: true}},
    setup(props){
        
        
        return {
            props,


            getActiveRecipe(){
                try {
                    let activeRecipe = AppState.recipes.find(recipe => recipe.id == props.recipe.id)
                    AppState.activeRecipe = activeRecipe
                    logger.log('setting active recipe', AppState.activeRecipe)
                } catch (error) {
                    Pop.error(error)
                }
            }

    }
    },

};
</script>


<style lang="scss" scoped>

</style>
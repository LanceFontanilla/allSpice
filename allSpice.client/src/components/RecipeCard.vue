<template>
    <ModalWrapper id="active-recipe">
    <template #button>   
        <div class="cover-img card bg-purple-light" @click="getActiveRecipe(recipe.id, recipe)">
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
    
    <template #body>
    <RecipeDetailsModal/>
    </template>
    </ModalWrapper>
</template>



<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
import ModalWrapper from '../components/ModalWrapper.vue'
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
export default {
    props: {recipe: {type: Recipe, required: true}},
    setup(){
        
        async function getActiveRecipe(recipeId){
            try {
                logger.log('open recipe details')
                await recipesService.getActiveRecipe(recipeId);
            } catch (error) {
                Pop.error(error)
            }
        }

        return {

    }
    },
    components: { ModalWrapper }
};
</script>


<style lang="scss" scoped>

</style>
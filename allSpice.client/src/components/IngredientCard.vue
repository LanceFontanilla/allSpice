<template>
<div>

        <div v-if="activeRecipe" class="ing-card card bg-secondary text-light ">
            <div class="card-header bg-dark text-center">
                <span class="header ">Ingredients</span>
            </div>                 
            <div class="card-body ">
                <template v-for="ingredient in activeRecipeIngredients" :key="ingredient.id">
                <div class="col-12">
                    <span class="fs-5"> {{ ingredient.quantity }} </span> <span class="fs-5 ms-1"> {{ ingredient.name }} </span>
                    <button v-if="activeRecipe.creatorId == accountId" title="Delete Ingredient" class="btn col-2 mb-1" @click.stop="deleteIngredient(ingredient.id)"><i class='fs-5 mdi mdi-delete-forever text-light'></i></button>
                </div>
                </template>
            </div>  

            <div v-if="activeRecipe.creatorId == accountId" class="card-footer bg-dark">
                <p class="p-0 m-0 d-flex align-items-center ">
                <IngredientForm/>          
                </p>
            </div> 
        
        </div>
    


</div>

</template>



<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref, watch, watchEffect } from 'vue';
import { Ingredient } from '../models/Ingredient';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
import { ingredientsService } from '../services/IngredientsService';
import { router } from '../router';

export default {
    props: {activeRecipeIngredient: {type: Ingredient, required: true}},
    setup() {
            
        const editable = ref({})
        
        watchEffect(() => {
            AppState.activeRecipeIngredients
        })
        return {
            accountId: computed(() => AppState.account.id),
            activeRecipeIngredients: computed(() => AppState.activeRecipeIngredients),
            activeRecipe: computed(() => AppState.activeRecipe),
            


            async deleteIngredient(ingredientId){
                try {
                    if(await Pop.confirm('Are you sure you want to delete this Ingredient?')){
                        await ingredientsService.deleteIngredient(ingredientId)
                        logger.log('this is the ingredient', ingredientId)
                        Pop.toast('You have deleted this ingredient', 'success', 'center' )
                    }
                } catch (error) {
                    Pop.error(error)
                }  
            },
            
            
        }
    },

};
</script>


<style lang="scss" scoped>
.bg-light-grey{
    background-color: rgba(125, 121, 121, 0.8) ;
}

.ing-card{
    height: 60vh;
    overflow-y: scroll;
    -ms-overflow-style: none;
    scrollbar-width: none; 
}
.ing-card::-webkit-scrollbar {
    display: none;
}

.header{
    font-size: 1.5rem;
}
</style>
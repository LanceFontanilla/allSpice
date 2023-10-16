<template>
<div>

        <div v-if="activeRecipe" class="ing-card card bg-secondary text-light ">
            <div class="card-header bg-dark text-center">
                <span class="header ">Ingredients</span>
            </div>                 
            <div class="card-body row">
                <div class="col-6">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> {{ activeRecipeIngredient.quantity }} </p>
                </div>
                <div class="col-6">
                    <p class="p-1 m-0 d-flex align-items-center "> {{ activeRecipeIngredient.name }}  </p>
                    

            </div>
        </div>  

            <div class="card-footer bg-dark">
                <p class="p-0 m-0 d-flex align-items-center ">
                <IngredientForm/>          
                </p>
            </div> 

        </div>
    


</div>

</template>



<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Ingredient } from '../models/Ingredient';

export default {
    props: {activeRecipeIngredient: {type: Ingredient, required: true}},
    setup() {
        return {
            activeRecipe: computed(() => AppState.activeRecipe),
            
            
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
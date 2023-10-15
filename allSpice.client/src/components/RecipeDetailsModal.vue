<template>
    <section class="container">
        <div class="row">
            <div class="col-4">
                <img class="img-fluid rec-img" src="https://images.unsplash.com/photo-1619531040576-f9416740661b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8Y2hlZXNlJTIwYnJlYWR8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=400&q=60" alt="">
            </div>
            
            <div class="col-8">
                <div class="row">
                    <div class="col-6 d-flex align-items-center p-4 pt-0">
                        <span class="title">Garlic Bread</span>
                    </div>            
                    <div class="col-6 d-flex align-items-center justify-content-end p-4 pt-0">
                        <span class="category px-3">Side Dish</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">

                        <div class="direct-card card">
                            <div class="card-header bg-dark text-center">
                                <span class="header ">
                                    Directions
                                </span>
                            </div>
                        <p class="card-body bg-secondary text-light mb-0">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Accusantium rem magnam voluptatum, est magni ea ut iusto, nulla atque nostrum cumque? Saepe sunt, fugiat vel sed iure deserunt consectetur nostrum.
                        </p>
                        </div>
                    </div>
                    
                    <div v-for="i in ingredients" :key="i.id" class="col-6">
                        <IngredientCard :ingredient="i"/>
                    </div>
            </div>
            </div>
        </div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger';
import IngredientCard from '../components/IngredientCard.vue'
export default {
    setup(){
        const route = useRoute()
        onMounted(()=> {
            getIngredientsByRecipe();
        });
        async function getIngredientsByRecipe(){
            try {
                const recipeId = route.params.recipeId
                await recipesService.getIngredientsByRecipe(recipeId);
                logger.log('getting ingredients by recipeId', recipeId)
            } catch (error) {
                Pop.error(error)
            }
        }


        return {  
            activeRecipe: computed(() => AppState.activeRecipe)
        }
    },
    components: { IngredientCard }
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
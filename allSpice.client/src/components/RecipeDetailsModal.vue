<template>
    <section class="container">
        <div class="row">
            <div class="col-4">
                <h1>Garlic Bread</h1>

            </div>            
            <div class="col-8 d-flex align-items-center">
                <span class="category">Side Dish</span>
            </div>
        </div>

        <div>
            <p>
                Ingredient
            </p>
        </div>
        <div>
            <h3>Directions</h3>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Accusantium rem magnam voluptatum, est magni ea ut iusto, nulla atque nostrum cumque? Saepe sunt, fugiat vel sed iure deserunt consectetur nostrum.
            </p>
        </div>
        <div>
            <img src="https://images.unsplash.com/photo-1619531040576-f9416740661b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8Y2hlZXNlJTIwYnJlYWR8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=400&q=60" alt="">
        </div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup(){

    return {  
        activeRecipe: computed(() => AppState.activeRecipe)
    }
    }
};
</script>


<style lang="scss" scoped>

.category{
    background-color: rgba(68, 62, 62, 0.887);
    color: whitesmoke;
    border-radius: 5px;
}

</style>
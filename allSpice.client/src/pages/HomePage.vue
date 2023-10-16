<template>
  <div class="container">
    <section class="row">
      <div class="header-card d-flex align-items-center mb-4">
        <p class="ms-3 fs-4 bg-dark-grey px-3 py-1 rounded">Let's Get Cooking with the best recipe management tool!</p>
      
      </div> 
    </section>


    <section class="row bg-light-purple gap-5 p-2 rounded my-2">

      <button class="btn col btn-outline-light" @click="filterBy = ''">All</button>
      <button class="btn col btn-outline-light" @click="filterBy = 'favorites'">Favorites</button>
      <button class="btn col btn-outline-light" @click="filterBy = 'myRecipes'">My Recipes</button>

    
    </section>

    <section class="row g-4 mt-3">

      <div v-for="r in recipes" :key="r.id" class="col-6 col-md-3">
        <RecipeCard :recipe="r"/>
      </div>

    </section>

  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import {recipesService} from '../services/RecipesService.js'
import {AppState} from '../AppState.js'

export default {
  setup() {
    onMounted(()=> {
      getRecipes();
    });
    const filterBy = ref('')
    async function getRecipes(){
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      filterBy,
      account: computed(() => AppState.account),
      
      recipes: computed(() => AppState.recipes),
      //   if(!filterBy.value){
      //     return AppState.recipes
      //    }else{
      //     return AppState.recipes.filter(recipe => recipe.type == filterBy.value)
      //    }
      // }),
    
    }
  }
}
</script>

<style scoped lang="scss">
.header-card{
  height: 40vh;
  background-image: url(https://chefsvisionknives.com/cdn/shop/articles/Colorful_Spoons-min_1200x.jpg?v=1668529918);
  background-position: center;
  background-size: cover;
  border: solid white 1px;
  border-radius: 10px;
  color: black;
}

.bg-dark-grey{
  background-color: rgba(42, 45, 58, 0.75);
  color: white
}

</style>

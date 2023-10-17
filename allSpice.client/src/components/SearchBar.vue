<template>
    <form @submit.prevent="searchRecipes" class="row">
        <div class="col-12 input-group">
            <input v-model="searchTerm.search" type="text" class="form-control" placeholder="search recipes">
            <button class="btn btn-primary"><i class="mdi mdi-magnify"></i></button>
        </div>
    </form>
    <div v-if="activeSearch" class="mt-2">
        <p>Searching for:</p>

        <span class="border border-primary rounded-pill p-2">{{ activeSearch }} <button @click="clearSearch" class="btn"><i
                    class="mdi mdi-close"></i></button></span>
    </div>
</template>

<script>
import { computed, ref } from 'vue';

import { recipesService } from '../services/RecipesService';


export default {

    setup() {

        const searchTerm = ref('')

        return {
            searchTerm,

            searchRecipes() {
                recipesService.searchRecipes(searchTerm.value)
            },

        };

    },
};
</script>


<style></style>
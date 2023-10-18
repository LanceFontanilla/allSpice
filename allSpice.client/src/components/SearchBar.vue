<template>
    <form @submit.prevent="searchRecipes" class="row">
        <div class="col-12 input-group">
            <input v-model="searchTerm.search" type="text" class="form-control" placeholder="search recipes">
            <button class="btn btn-primary"><i class="mdi mdi-magnify"></i></button>
        </div>
    </form>

</template>

<script>
import { computed, ref } from 'vue';

import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';


export default {

    setup() {

        const searchTerm = ref({})

        return {
            searchTerm,

            searchRecipes() {
                recipesService.searchRecipes(searchTerm.value)
                logger.log('this is the searchTermValue',searchTerm.value)
            },

        };

    },
};
</script>


<style></style>
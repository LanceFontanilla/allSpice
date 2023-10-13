<template>

<div class="cover-img card bg-purple-light ">

        <div class="p-0 ms-2 mt-2">
        <p  class="fw-bold mb-0">{{ recipe.title }}</p>
        </div>
        <div class="">
        <p class="p-0 ms-2 mb-0">{{ recipe.category }}</p>
        </div>
        <div class="">
        <p class="p-0 ms-2 mb-0"><img class="img-fluid" :src="recipe.img" alt=""></p>
        </div>
</div>

</template>



<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
export default {
    props: {recipe: {type: Recipe, required: true}},
    setup(){
    return {

    }
    }
};
</script>


<style lang="scss" scoped>

</style>
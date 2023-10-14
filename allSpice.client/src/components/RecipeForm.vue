

<template>
    <div class="container-fluid">
        <form class="row" @submit.prevent="createRecipe">

            <div class="mb-1 col-6">
                <label for="recipe-title">Title</label>
                <input v-model="recipeData.title" id="recipe-title" class="form-control" type="text" minlength="5"
                    maxlength="50" placeholder="title of recipe" required>
            </div>
            <div class="mb-1 col-6">
                <label for="recipe-category">Category</label>
                <select v-model="recipeData.category" class="form-control" id="recipe-category" required>
                    <option disabled selected value="">Please Select a Category</option>
                    <option value="Appetizer">Appetizer</option>
                    <option value="MainCourse">Main Course</option>
                    <option value="Dessert">Dessert</option>
                    <option value="SideDish">SideDish</option>
                    <option value="Drink">Drink</option>
                    <option value="Other">Other</option>
                </select>
            </div>
            <div class="form-group">
                <label for="Instructions">Instructions</label>
                <textarea v-model="recipeData.Instructions" type="text" class="form-control" placeholder="Recipe Instructions"
                    maxlength="1000"> </textarea>
            </div>
            <div class="mb-1 col-12">
                <label for="recipe-img">Recipe Image</label>
                <input v-model="recipeData.img" id="recipe-img" class="form-control" type="url" minlength="5"
                    maxlength="500" placeholder="url of recipe image" required>
            </div>
            <div class="mb-1 col-12">
                <img class="img-fluid preview-image" :src="recipeData.img" alt="">
            </div>
            <div class="col-12 text-end">
                <button class="btn btn-secondary">Submit</button>
            </div>
        </form>
    </div>
</template>

<script>
import { onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';
import Pop from '../utils/Pop';

import { Modal } from 'bootstrap';
import { recipesService } from '../services/RecipesService';

export default {
    setup() {
        const recipeData = ref({})
        const router = useRouter()
        function resetForm() {
            recipeData.value = { type: '' }
        }
        onMounted(() => {
            resetForm()
        })
        return {
            recipeData,
            async createRecipe() {
                try {
                    let newRecipe = await recipesService.createRecipe(recipeData.value)
                    Pop.toast('Recipe Created', 'success', 'center')
                    resetForm()
                    Modal.getOrCreateInstance('#create-recipe').hide()
                    // router.push({ name: 'Recipe Details', params: { recipeId: newRecipe.id } })
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
};
</script>


<style></style>
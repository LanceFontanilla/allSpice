

<template>
    <div class="container-fluid">
        <form class="row" @submit.prevent="createIngredient">
            <div class="mb-1 col-5">
                <label for="ingredient-quantity">Quantity</label>
                <input v-model="ingredientData.quantity" id="ingredient-quantity" class="form-control" type="text" minlength="1"
                    maxlength="25" placeholder="quantity" required>
            </div>

            <div class="mb-1 col-5">
                <label for="ingredient-name">Ingredient</label>
                <input v-model="ingredientData.name" id="ingredient-name" class="form-control" type="text" minlength="1"
                    maxlength="50" placeholder="Ingredient" required>
            </div>

            <div class="col-1 d-flex align-items-end mb-1 text-end">
                <button type="submit" class="btn btn-secondary">+</button>
            </div>
        </form>
    </div>
</template>

<script>
import { onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';
import Pop from '../utils/Pop';

import { ingredientsService } from '../services/IngredientsService';

export default {
    setup() {
        const ingredientData = ref({})

        function resetForm() {
            ingredientData.value = { type: '' }
        }
        onMounted(() => {
            resetForm()
        })
        return {
            ingredientData,
            async createIngredient() {
                try {
                    await ingredientsService.createIngredient(ingredientData.value)
                    Pop.toast('Ingredient Created', 'success', 'center')
                    resetForm()
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
};
</script>


<style></style>
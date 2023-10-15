

<template>
    <div class="container-fluid">
        <form class="row" @submit.prevent="createIngredient">
            <div class="mb-1 col-6">
                <label for="ingredient-quantity">Quantity</label>
                <input v-model="ingredientData.quantity" id="ingredient-quantity" class="form-control" type="text" minlength="1"
                    maxlength="10" placeholder="quantity" required>
            </div>

            <div class="mb-1 col-6">
                <label for="ingredient-name">Ingredient Name</label>
                <input v-model="ingredientData.name" id="ingredient-name" class="form-control" type="text" minlength="1"
                    maxlength="50" placeholder="Ingredient" required>
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
import { ingredientsService } from '../services/IngredientsService';

export default {
    setup() {
        const ingredientData = ref({})
        const router = useRouter()
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
                    let newIngredient = await ingredientsService.createIngredient(ingredientData.value)
                    Pop.toast('Ingredient Created', 'success', 'center')
                    resetForm()
                    Modal.getOrCreateInstance('#create-ingredient').hide()
                    // router.push({ name: 'Ingredient Details', params: { ingredientId: newIngredient.id } })
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
};
</script>


<style></style>
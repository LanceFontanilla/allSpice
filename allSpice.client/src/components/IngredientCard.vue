<template>
<div>

        <div class="cover-img card bg-purple-light ">
            <div class="card-header ">

            </div>
            <div class="p-0 m-2 mt-2">
                <p class="fw-bold ">{{ ingredient.name }}</p>
            </div>
            <div class="">
                <p class="p-0 m-2 ">{{ ingredient.quantity }}</p>
            </div>
            
        </div>
    


</div>

</template>



<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Ingredient } from '../models/Ingredient';

export default {
    props: { recipe: { type: Ingredient, required: true } },
    setup() {
        return {

        }
    },

};
</script>


<style lang="scss" scoped></style>
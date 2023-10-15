<template>
<div>

        <div class="ing-card card bg-secondary text-light ">
            <div class="card-header bg-dark text-center">
                <span class="header ">Ingredients</span>
            </div>                 
            <div class="card-body row">
                <div class="col-1">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> 1000 </p>
                </div>
                <div class="col-11">
                    <p class="p-1 m-0 d-flex align-items-center "> Bacon strips, chopped  </p>
                </div>
                <div class="col-1">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> 4 </p>
                </div>
                <div class="col-11">
                    <p class="p-1 m-0 d-flex align-items-center "> Bacon strips, chopped  </p>
                </div>
                <div class="col-1">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> 4 </p>
                </div>
                <div class="col-11">
                    <p class="p-1 m-0 d-flex align-items-center "> Bacon strips, chopped  </p>
                </div>
                <div class="col-1">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> 4 </p>
                </div>
                <div class="col-11">
                    <p class="p-1 m-0 d-flex align-items-center "> Bacon strips, chopped  </p>
                </div>
                <div class="col-1">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> 4 </p>
                </div>
                <div class="col-11">
                    <p class="p-1 m-0 d-flex align-items-center "> Bacon strips, chopped  </p>
                </div>
                <div class="col-1">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> 4 </p>
                </div>
                <div class="col-11">
                    <p class="p-1 m-0 d-flex align-items-center "> Bacon strips, chopped  </p>
                </div>
                <div class="col-1">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> 4 </p>
                </div>
                <div class="col-11">
                    <p class="p-1 m-0 d-flex align-items-center "> Bacon strips, chopped  </p>
                </div>
                <div class="col-1">
                    <p class="p-1 m-0 d-flex align-items-center justify-content-center "> 4 </p>
                </div>





            </div>  
    <!-- <ModalWrapper id="add-ingredient">
        <template #button>  -->
            <div class="card-footer bg-dark">
                <p class="p-0 m-0 d-flex align-items-center ">
              <IngredientForm/>          
                </p>
            </div> 
        <!-- </template>
        
        <template #body> -->

        <!-- </template>
    </ModalWrapper> -->
        </div>
    


</div>

</template>



<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Ingredient } from '../models/Ingredient';
import ModalWrapper from '../components/ModalWrapper.vue'
export default {
    props: { ingredient: { type: Ingredient, required: true } },
    setup() {
        return {

        }
    },
    components: { ModalWrapper }
};
</script>


<style lang="scss" scoped>
.bg-light-grey{
    background-color: rgba(125, 121, 121, 0.8) ;
}

.ing-card{
    height: 60vh;
    overflow-y: scroll;
    -ms-overflow-style: none;
    scrollbar-width: none; 
}
.ing-card::-webkit-scrollbar {
    display: none;
}

.header{
    font-size: 1.5rem;
}
</style>
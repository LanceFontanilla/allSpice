

<template>
    <div class="container-fluid">
        <form class="row" @submit.prevent="createRecipe">

            <div class="mb-1 col-6">
                <label for="event-name">Name</label>
                <input v-model="eventData.name" id="event-name" class="form-control" type="text" minlength="5"
                    maxlength="50" placeholder="name of event" required>
            </div>
            <div class="mb-1 col-6">
                <label for="event-type">Type</label>
                <select v-model="eventData.type" class="form-control" id="event-type" required>
                    <option disabled selected value="">please select a type</option>
                    <option value="concert">concerts</option>
                    <option value="convention">conventions</option>
                    <option value="sport">sports</option>
                    <option value="digital">digital</option>
                </select>
            </div>
            <div class="mb-1 col-6">
                <label for="event-location">Location</label>
                <input v-model="eventData.location" id="event-location" class="form-control" type="text" minlength="5"
                    maxlength="500" placeholder="location of event" required>
            </div>
            <div class="mb-1 col-6">
                <label for="event-capacity">Capacity</label>
                <input v-model="eventData.capacity" id="event-capacity" class="form-control" type="number" min="1"
                    max="5000" placeholder="capacity of event" required>
            </div>
            <div class="mb-1 col-6">
                <label for="event-startDate">Date</label>
                <input v-model="eventData.startDate" id="event-startDate" class="form-control" type="date"
                    placeholder="date of event" required>
            </div>
            <div class="form-group">
                <label for="Description">Description</label>
                <textarea v-model="eventData.description" type="text" class="form-control" placeholder="description"
                    maxlength="1000"> </textarea>
            </div>
            <div class="mb-1 col-12">
                <label for="event-cover">Cover Image</label>
                <input v-model="eventData.coverImg" id="event-cover" class="form-control" type="url" minlength="5"
                    maxlength="500" placeholder="url of cover image" required>
            </div>
            <div class="mb-1 col-12">
                <img class="img-fluid preview-image" :src="eventData.coverImg" alt="">
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
        const eventData = ref({})
        const router = useRouter()
        function resetForm() {
            eventData.value = { type: '' }
        }
        onMounted(() => {
            resetForm()
        })
        return {
            eventData,
            async createEvent() {
                try {
                    let newRecipe = await recipesService.createRecipe(eventData.value)
                    Pop.toast('Event Created', 'success', 'center')
                    resetForm()
                    Modal.getOrCreateInstance('#create-event').hide()
                    router.push({ name: 'Event Details', params: { eventId: newEvent.id } })
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
};
</script>


<style></style>
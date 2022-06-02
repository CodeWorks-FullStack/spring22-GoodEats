<template>
  <div class="restaurant bg-white d-flex rounded elevation-2" @click="setActive">
    <img class="object-fit rounded-start" :src="restaurant.image" alt="">
    <div class="d-flex flex-column justify-content-center ms-3">
      <h3 class="m-0 border-bottom border-danger">{{ restaurant.name }}</h3>
      <p>{{ restaurant.address }}</p>
    </div>
    <div class="flex-grow-1 text-end p-3">
      <h2><i class="mdi mdi-star text-warning"></i>{{ restaurant.averageRating.toFixed(1) }} ({{ restaurant.totalReviews
      }})</h2>
    </div>
  </div>
</template>


<script>
import { Modal } from 'bootstrap'
import { AppState } from '../AppState.js'
import { reviewsService } from '../services/ReviewsService.js'
import Pop from '../utils/Pop.js'

export default {
  props: {
    restaurant: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async setActive() {
        try {
          AppState.activeRestaurant = props.restaurant
          await reviewsService.getReviews(props.restaurant.id)
          Modal.getOrCreateInstance(document.getElementById('restaurant-modal')).show()
        } catch (error) {
          Pop.toast("Restaurant not available")
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.restaurant {
  cursor: pointer;

  &:hover {
    transform: scale(1.02);
  }
}

img {
  height: 20vh;
  width: 20vw;
}
</style>
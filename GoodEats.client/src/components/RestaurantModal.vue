<template>
  <Modal id="restaurant-modal">
    <template #modal-body>
      <div class="container-fluid position-relative">
        <button type="button" class="btn-close position-absolute close-button" data-bs-dismiss="modal"
          aria-label="Close"></button>
        <div class="row">
          <div class="col-md-6 col-12 p-0">
            <img class="object-fit w-100 rounded-start" :src="restaurant.image">
          </div>
          <div class="col-md-6 col-12 p-5">
            <div class="d-flex flex-column justify-content-center ms-3">
              <div class="border-bottom border-danger d-flex justify-content-between">
                <h3 class="m-0">{{ restaurant.name?.toUpperCase() }}</h3>
                <h3><i class="mdi mdi-star text-warning"></i>{{ restaurant.averageRating?.toFixed(1) }} ({{
                    restaurant.totalReviews
                }})</h3>
              </div>
              <p>{{ restaurant.address }}</p>
            </div>
            <div class="m-3 bg-danger darken-10" v-if="user.isAuthenticated">
              <form class="p-4">
                <label for="rating" class="form-label text-white">Rating {{ newReview.rating }}</label>
                <input type="range" class="form-range" id="rating" min="1" max="5" step="1" v-model="newReview.rating">
                <textarea class="w-100" placeholder="Review..." v-model="newReview.comment"></textarea>
                <div class="text-end">
                  <button class="btn btn-success">Submit</button>
                </div>
              </form>
            </div>
            <div class="mx-3 reviews scrollable-y">
              <div v-for="rv in reviews" :key="rv.id">
                <Review :review="rv" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </template>
  </Modal>
</template>


<script>
import { computed, ref } from 'vue'
import { AppState } from '../AppState.js'

export default {
  setup() {
    const newReview = ref({ rating: 3 })
    return {
      newReview,
      restaurant: computed(() => AppState.activeRestaurant),
      reviews: computed(() => AppState.restaurantReviews),
      user: computed(() => AppState.user)
    }
  }
}
</script>


<style lang="scss" scoped>
.close-button {
  right: 1em;
  top: 1em;
}

img {
  min-height: 70vh;

}

.reviews {
  max-height: 60vh;
}
</style>
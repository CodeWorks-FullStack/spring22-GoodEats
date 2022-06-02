<template>
  <div class="profile container">
    <div class="row mt-3">
      <div class="col-md-6 d-flex">
        <img class="rounded-circle object-fit" :src="profile.picture">
        <div class="d-flex flex-column justify-content-center ms-2">
          <h1 class="m-0">{{ profile.name }}</h1>
          <h4 class="m-0">Total Reviews: {{ reviews.length }}</h4>
          <h4 class="m-0">Average Review: {{ averageReview.toFixed(2) }}</h4>
        </div>
      </div>
    </div>
    <!-- MASONRY-CONTAINER CANNOT BE DONE IN A ROW!!!!!!!!!!!!!!! NO D-FLEX -->
    <div class="masonry-container">
      <div v-for="rv in reviews" :key="rv.id">
        <Review :review="rv" />
      </div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState.js'
import { profilesService } from '../services/ProfilesService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {
  setup() {
    const route = useRoute()
    onMounted(async () => {
      try {
        await profilesService.getProfile(route.params.id)
      } catch (error) {
        logger.log("Profile.... ", error)
        Pop.toast("You done messed up")
      }
    })
    return {
      profile: computed(() => AppState.profile),
      reviews: computed(() => AppState.profileReviews),
      averageReview: computed(() => {
        let total = 0
        AppState.profileReviews.forEach(r => {
          total += r.rating
        })
        return total / AppState.profileReviews.length
      })
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 200px;
  width: 200px;
}

.masonry-container {
  columns: 4;

  // column-gap: 10px;
  div {
    break-inside: avoid;
  }
}
</style>
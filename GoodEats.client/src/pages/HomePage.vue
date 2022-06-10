<template>
  <div class="home container">
    <div class="row justify-content-center">
      <div class="col-12 col-md-8 my-3" v-for="r in restaurants" :key="r.id">
        <Restaurant :restaurant="r" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState.js'
import { restaurantsService } from '../services/RestaurantsService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {
  setup() {

    onMounted(async () => {
      try {
        await restaurantsService.getAll()
      } catch (error) {
        logger.error(error)
        Pop.toast('Unable to get Restaurants', 'error')
      }
    })

    return {

      restaurants: computed(() => AppState.restaurants)
    }
  }
}
</script>

<style scoped lang="scss">
</style>

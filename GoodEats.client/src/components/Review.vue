<template>
  <div class="review text-white p-2">
    <div class="bg-danger darken-10 p-2">
      <h4 contenteditable @blur="edit">"{{ review.comment }}"</h4>
      <div class="text-end">
        <p @click="goToProfile" class="action"><em>- {{ review.creator.name }} {{ review.rating }} <i
              class="mdi mdi-star"></i> </em></p>
      </div>
    </div>
  </div>
</template>

<script>
import { Modal } from 'bootstrap'
import { useRouter } from 'vue-router'

export default {
  props: {
    review: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const router = useRouter()
    return {
      goToProfile() {
        Modal.getOrCreateInstance(document.getElementById('restaurant-modal')).hide()
        router.push({ name: 'Profile', params: { id: props.review.creatorId } })
      },
      edit() {
        console.log(window.event.target.innerText)
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>
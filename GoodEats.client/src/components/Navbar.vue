<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-white px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo"
          src="https://sk3xr2l1ehb173e733q2ty1q-wpengine.netdna-ssl.com/wp-content/uploads/GEB_LogoReworkFinal-1024x1024.png"
          height="50" />
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon" />
    </button>
    <div class="collapse navbar-collapse d-md-flex justify-content-end" id="navbarText">
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
export default {
  setup() {
    return {}
  },
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>

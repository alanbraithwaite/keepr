<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <div class="fixed-top d-flex justify-content-center"><button @click="logout">Logout</button></div>
  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
    }
  };
</script>
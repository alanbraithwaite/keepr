<template>

  <div id="app" class="row d-flex justify-content-center">
    <router-link to="/">Home</router-link> |
    <router-link v-if="user.id" to="/dashboard">Dashboard</router-link> |
    <router-link v-if="!user.id" to="/login">Login</router-link> |
    <router-link to="/about">About</router-link>
    <!-- <div v-if="user.id" class="fixed-top d-flex justify-content-end"> -->
    <button @click="logout">Logout</button>
    <!-- </div> -->
  </div>

</template>

<script>

  export default {
    name: 'navbar',
    data() {
      return {
        isLoggedIn: false,
      }
    },

    computed: {
      user() {
        return this.$store.state.user
      },
    },

    methods: {

      logout() {
        this.$store.dispatch('logout')
      },
    }




  }

</script>


<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>
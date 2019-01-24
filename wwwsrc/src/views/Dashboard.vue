<template>
  <div class="">
    <div class="row d-flex justify-content-center">
      <div class=" card">
        <img src="http://placehold.it/150x150" alt="">
        <span class="name">
          <h1>Manage Vaults Here</h1>
        </span>
        <button @click="getVaults">Manage Vaults</button>
      </div>
      <div class="card">
        <img src="http://placehold.it/150x150" alt="">
        <span class="name">
          <h1>Manage Keeps Here</h1>
        </span>
        <button @click="getUserKeeps">Manage Keeps</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'dashboard',
    data() {
      return {
      }
    },

    computed: {

    },

    methods: {
      getVaults() {
        this.$store.dispatch('getVaults');
      },
      getUserKeeps() {
        this.$store.dispatch('getUserKeeps');
      },


    },

    components: {}
  }

</script>

<style>


</style>
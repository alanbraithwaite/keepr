<template>
  <div class="">
    <div class="row d-flex justify-content-center">
      <div class=" card">
        <img src="http://placehold.it/150x150" alt="">
        <span class="name">
          <h1>Manage Vaults Here</h1>
        </span>
        <!-- <button @click="getVaults">Manage Vaults</button> -->
        <router-link :to="'vaults'">
          <h4>Manage Vaults</h4>
        </router-link>


      </div>
      <div class="row d-flex justify-content-center card">
        <img src="https://s3.amazonaws.com/images.gearjunkie.com/uploads/2018/05/nanga-parbat.jpg" height="150" width="200"
          alt="">
        <span class="name">
          <h1>Manage Keeps Here</h1>
        </span>

        <router-link :to="'keeps'">
          <h4>Manage Keeps</h4>
        </router-link>


        <!-- <button @click="getUserKeeps">Manage Keeps</button> -->
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


    },

    components: {}
  }

</script>

<style>


</style>
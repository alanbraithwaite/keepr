<template>
  <div class="">
    <div class=" ">
      <h1>Your Keeps</h1>

      <div class="row">
        <div class="row col d-flex justify-content-center" v-for="keep in userkeeps" :key="keep.id">
          <div class=" card">
            <img :src="keep.img" height="150" width="200">
            <span class="name">{{keep.name}}</span>
            <span class="kept"><i class="far fa-thumbs-up"></i>Kept: {{keep.keeps}}</span>
            <span class="views"><i class="far fa-eye"></i>Views: {{keep.views}} </span>
            <div> <button @click=""><i class="fas fa-trash"></i></button>
              <button class="" @click=" ">View</button>
              <button @click=""><i class="fas fa-minus"></i></button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'keeps',
    data() {
      return {

      }
    },
    computed: {
      userkeeps() {
        return this.$store.state.userkeeps;
      },

    },
    methods: {}
  }

</script>

<style>


</style>
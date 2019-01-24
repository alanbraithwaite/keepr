<template>
  <div class="">
    <div class="row">
      <div class="row d-flex justify-content-center">
        <div class=" card">
          <img :src="keep.img" height="150" width="200">
          <span class="name">{{keep.name}}</span>
          <span class="kept"><i class="far fa-thumbs-up"></i>Kept: {{keep.keeps}}</span>
          <span class="views"><i class="far fa-eye"></i>Views: {{keep.views}} </span>
          <button @click="getKeep">View</button>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: '',
    data() {
      return {

      }
    },
    computed: {
      // getKeep() {
      //   this.$store.
      // }
    },
    methods: {

    }
  }

</script>

<style>


</style>
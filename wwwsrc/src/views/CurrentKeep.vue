<template>
  <div class="">
    <div class="row">
      <div class="row d-flex justify-content-center">
        <div class=" card">
          <span class="img">{{keep.img}}</span>
          <img :src="keep.img" height="150" width="200">
          <span class="name">{{keep.name}}</span>
          <span class="kept"><i class="far fa-thumbs-up"></i>Kept: {{keep.keeps}}</span>
          <span class="views"><i class="far fa-eye"></i>Views: {{keep.views}} </span>
          <button @click="">Close</button>
          <router-link :to="{name: 'keeps'}">back</router-link>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: 'currentkeep',
    data() {
      return {

      }
    },
    computed: {
      keepId() {
        return this.$route.params.keepId
      },
      keep() {
        return this.$store.state.userkeeps.find(k => k.id == this.keepId) || {}
      }
    },

    methods: {

    }
  }

</script>

<style>


</style>
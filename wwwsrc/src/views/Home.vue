<template>
  <div class="home">
    <h1>Welcome to Outdoor Ideas Keepr!</h1>
    <div class="row">
      <div class="row d-flex justify-content-center" v-for="keep in publickeeps" :key="keep.id">
        <div class=" card">
          <img :src="keep.img" height="150" width="200">
          <span class="name">{{keep.name}}</span>
          <span class="kept"><i class="far fa-thumbs-up"></i>Kept: {{keep.keeps}}</span>
          <span class="views"><i class="far fa-eye"></i>Views: {{keep.views}} </span>
          <button @click="">View</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import keep from "@/components/keep.vue"

  export default {
    name: "home",
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getPublicKeeps");

      //   //blocks users not logged in
      //   if (!this.$store.state.user.id) {
      //     this.$router.push({ name: "login" });
      // }
    },

    computed: {
      publickeeps() {
        return this.$store.state.publickeeps;
      }
    },


    methods: {


    }
  };
</script>
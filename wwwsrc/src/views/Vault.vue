<template>
  <div class="">
    <div class=" row col d-flex justify-content-center">
      <div class="col d-flex justify-content-center">
        <h1>Vault name goes here</h1>
      </div>
    </div>
    <div class="row col d-flex justify-content-center" v-for="keep in vaultkeeps" :key="keep.id">
      <div class=" card">
        <img :src="keep.img" height="150" width="200">
        <span class="name">{{keep.name}}</span>
        <span class="kept"><i class="far fa-thumbs-up"></i>Kept: {{keep.keeps}}</span>
        <span class="views"><i class="far fa-eye"></i>Views: {{keep.views}} </span>
        <button @click="removeFromVault"><i class="fas fa-minus"></i></button>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'vault',
    data() {
      return {
      }
    },
    computed: {
      vaultkeeps(keepId) {
        return this.$store.state.vaultkeeps;
      },
      activevault() {
        this.$store.state.activevault;
      }


    },
    methods: {

      removeFromVault() {
        this.$store.dispatch("removeFromVault", keepId);
      }
    }
  }

</script>

<style>


</style>
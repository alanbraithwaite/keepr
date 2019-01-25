<template>
  <div class="home">
    <h1>Welcome to Outdoor Ideas Keepr!</h1>
    <div class="row">
      <div class="row col d-flex justify-content-center" v-for="keep in publickeeps" :key="keep.id">
        <div class=" card">
          <img :src="keep.img" height="150" width="200">
          <span class="name">{{keep.name}}</span>
          <span class="kept"><i class="far fa-thumbs-up"></i>Kept: {{keep.keeps}}</span>
          <span class="views"><i class="far fa-eye"></i>Views: {{keep.views}} </span>
          <router-link :to="{name: 'homecurrentkeep', params: {keepId: keep.id}}">
            <h4>VIEW</h4>
          </router-link>
          <button type="button" @click.prevent="addKeepToVault(keep.id)">Add to Vault</button>
          <select v-model="selectedVault">
            <option v-for="vault in vaults" class="custom-select" :value="vault.id">{{vault.name}}</option>
          </select>
          <!-- :key="vault.id" -->
        </div>
      </div>
    </div>

  </div>
</template>

<script>

  export default {
    name: "home",
    data() {

      return {
        // selectedVault: 'Add to Vault',

      }
    },
    mounted() {
      this.$store.dispatch("getPublicKeeps");

      //   //blocks users not logged in
      //   if (!this.$store.state.user.id) {
      //     this.$router.push({ name: "login" });
      // }
    },

    methods: {
      addKeepToVault(keepId) {
        // creats a keyvaule pair

        let payload =
        {
          keepId: keepId,
          vaultId: this.selectedVault
        }
        this.$store.dispatch('addKeepToVault', payload)
        debugger
      },
    },

    computed: {
      publickeeps() {
        return this.$store.state.publickeeps;
      },
      vaults() {
        return this.$store.state.vaults;
      },

    },


    methods: {


    }
  };
</script>

<style>
  body {
    background: url('https://s3.amazonaws.com/images.gearjunkie.com/uploads/2018/05/nanga-parbat.jpg')no-repeat center center fixed;
    background-size: cover;
  }
</style>